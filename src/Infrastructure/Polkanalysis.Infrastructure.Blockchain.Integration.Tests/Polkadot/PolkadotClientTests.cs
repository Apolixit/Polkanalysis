using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Polkanalysis.Abstract.Tests;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot
{
    internal class PolkadotClientTests : GlobalIntegrationTest
    {
        //private PeopleChainService _peopleChainService = default!;
        //private PolkadotService _substrateService = default!;

        //Don't connect
        public override Task ConnectAsync() { return Task.CompletedTask; }
        // Don't disconnect
        public override Task DisconnectAsync() { return Task.CompletedTask; }

        protected override ISubstrateService MockSubstrateService()
        {
            var peopleChainIntegration = new PeopleChain.PeopleChainIntegrationTests();

            return new PolkadotService(
                    _substrateEndpoints,
                    new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>()),
                    Substitute.For<ILogger<PolkadotService>>(),
                    (PeopleChainService)peopleChainIntegration.GetSubstrateService(),
                    _serviceProvider);
        }

        [SetUp]
        public async Task SetupAsync()
        {
            // I got some trouble with parallel test, so I will make sure to close the connection before starting a new test
            if (_substrateService.IsConnected())
            {
                await _substrateService.CloseAsync(CancellationToken.None);
            }

            Assert.That(_substrateService.IsConnected(), Is.False);
        }

        [TearDown]
        public async Task TeardownAsync()
        {
            await _substrateService.CloseAsync(CancellationToken.None);
        }

        [Test]
        public async Task Connect_ShouldConnectToPolkadotAndItDependenciesSuccessfullyAsync()
        {
            Assert.That(_substrateService.AjunaClient.IsConnected, Is.False);
            Assert.That(_substrateService.ChainDependencies.All(x => x.IsConnected() == false));

            await _substrateService.ConnectAsync(CancellationToken.None);

            Assert.That(_substrateService.AjunaClient.IsConnected, Is.True);
            Assert.That(_substrateService.ChainDependencies.All(x => x.IsConnected() == true));

            await _substrateService.CloseAsync(CancellationToken.None);

            Assert.That(_substrateService.AjunaClient.IsConnected, Is.False);
            Assert.That(_substrateService.ChainDependencies.All(x => x.IsConnected() == false));
        }

        [Test]
        public async Task Connect_ShouldTriggerEventForPolkadotAndDependenciesAsync()
        {
            var onConnectionSetTriggered = new TaskCompletionSource<bool>();
            var onConnectionSetTriggeredForPeopleChain = new TaskCompletionSource<bool>();

            _substrateService.AjunaClient.ConnectionSet += (sender, e) => onConnectionSetTriggered.SetResult(true);
            _substrateService.ChainDependencies.First().AjunaClient.ConnectionSet += (sender, e) => onConnectionSetTriggeredForPeopleChain.SetResult(true);

            await _substrateService.ConnectAsync(CancellationToken.None);

            await Task.WhenAll(
                Task.WhenAny(onConnectionSetTriggered.Task, Task.Delay(TimeSpan.FromMinutes(1))),
                Task.WhenAny(onConnectionSetTriggeredForPeopleChain.Task, Task.Delay(TimeSpan.FromMinutes(1)))
            );

            Assert.That(onConnectionSetTriggered.Task.IsCompleted, Is.True);
            Assert.That(onConnectionSetTriggeredForPeopleChain.Task.IsCompleted, Is.True);
        }

        [Test, Ignore("Todo debug already connected")]
        public async Task OnConnectionLost_ShouldThrowDisconnectedEventAsync()
        {
            var onConnectionLostTriggered = new TaskCompletionSource<bool>();
            var onConnectionLostTriggeredForPeopleChain = new TaskCompletionSource<bool>();

            _substrateService.AjunaClient.ConnectionLost += (sender, e) => onConnectionLostTriggered.SetResult(true);
            _substrateService.ChainDependencies.First().AjunaClient.ConnectionLost += (sender, e) => onConnectionLostTriggeredForPeopleChain.SetResult(true);

            await _substrateService.ConnectAsync(CancellationToken.None);
            await _substrateService.CloseAsync(CancellationToken.None);

            await Task.WhenAll(
                await Task.WhenAny(onConnectionLostTriggered.Task, Task.Delay(TimeSpan.FromMinutes(1))),
                await Task.WhenAny(onConnectionLostTriggeredForPeopleChain.Task, Task.Delay(TimeSpan.FromMinutes(1)))
            );

            Assert.That(onConnectionLostTriggered.Task.IsCompleted, Is.True);
            Assert.That(onConnectionLostTriggeredForPeopleChain.Task.IsCompleted, Is.True);
        }

        [Test, Ignore("Debug this when multiple run")]
        public async Task ManuallyDisconnect_ShouldNotTryToReconnectAsync()
        {
            await _substrateService.ConnectAsync(CancellationToken.None);
            Assert.That(_substrateService.IsConnected(), Is.True);

            await _substrateService.CloseAsync(CancellationToken.None);
            Assert.That(_substrateService.IsConnected(), Is.False);
        }

        [Test, Ignore("Todo debug already connected")]
        public async Task DisconnectedPrematurely_ShouldTryToReconnectAsync()
        {
            var onReconnectedTriggered = new TaskCompletionSource<(bool, int)>();
            _substrateService.AjunaClient.OnReconnected += (sender, e) => onReconnectedTriggered.SetResult((true, e));

            await _substrateService.ConnectAsync(CancellationToken.None);
            await _substrateService.AjunaClient._socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);

            await Task.WhenAny(onReconnectedTriggered.Task, Task.Delay(TimeSpan.FromMinutes(1)));

            Assert.That(_substrateService.AjunaClient.IsConnected, Is.True);
        }

        //[Test]
        //public async Task ConnectToFirstNode_ThenTooMuchRequests_ShouldConnectToTheSecondNodeAsync()
        //{
        //    await _substrateService.ConnectAsync(CancellationToken.None);
        //    Assert.That(_substrateService.IsConnected(), Is.True);

        //    var firstProviderName = _substrateService.EndpointInformation.Name;
        //    Assert.That(_substrateService.EndpointInformation.Name, Is.Not.Null);

        //    // Close to simulate too much requests
        //    _substrateService.AjunaClient.InvokeAsync<U32>("plouf", "ok", CancellationToken.None).ThrowsAsync<WebSocketException>();

        //    await _substrateService.AjunaClient.InvokeAsync<U32>("plouf", "ok", CancellationToken.None);

        //    Assert.That(_substrateService.IsConnected(), Is.True);
        //    var secondProviderName = _substrateService.EndpointInformation.Name;
        //    Assert.That(secondProviderName, Is.Not.Null);
            
        //    Assert.That(firstProviderName, Is.EqualTo(secondProviderName));
        //}
    }
}
