using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot
{
    internal class PolkadotClientTests
    {
        private PeopleChainService _peopleChainService = default!;
        private PolkadotService _polkadotService = default!;

        [OneTimeSetUp]
        protected void Init()
        {
            var peopleChainIntegration = new PeopleChain.PeopleChainIntegrationTests();
            _peopleChainService = new PeopleChainService(
                    peopleChainIntegration.GetEndpoint(),
                    new PeopleChainMapping(Substitute.For<ILogger<PeopleChainMapping>>()),
                    Substitute.For<ILogger<PeopleChainService>>()
                    );

            //var polkadotIntegration = new PolkadotIntegrationTest();
            _polkadotService = new PolkadotService(
                    GetPolkadotEndpoint(),
                    new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>()),
                    Substitute.For<ILogger<PolkadotService>>(),
                    _peopleChainService);
        }

        internal ISubstrateEndpoint GetPolkadotEndpoint()
        {
            var substrateConfigurationMock = Substitute.For<ISubstrateEndpoint>();

            substrateConfigurationMock.BlockchainName.Returns("Polkadot");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri("wss://dot-rpc.stakeworld.io"));

            return substrateConfigurationMock;
        }

        [SetUp]
        public async Task SetupAsync()
        {
            // I got some trouble with parallel test, so I will make sure to close the connection before starting a new test
            if(_polkadotService.IsConnected())
            {
                await _polkadotService.CloseAsync(CancellationToken.None);
            }
            
            Assert.That(_polkadotService.IsConnected(), Is.False);
        }
        
        [TearDown]
        public async Task TeardownAsync()
        {
            await _polkadotService.CloseAsync(CancellationToken.None);
        }

        [Test]
        public async Task Connect_ShouldConnectToPolkadotAndItDependenciesSuccessfullyAsync()
        {
            Assert.That(_polkadotService.AjunaClient.IsConnected, Is.False);
            Assert.That(_polkadotService.ChainDependencies.All(x => x.IsConnected() == false));

            await _polkadotService.ConnectAsync(CancellationToken.None);

            Assert.That(_polkadotService.AjunaClient.IsConnected, Is.True);
            Assert.That(_polkadotService.ChainDependencies.All(x => x.IsConnected() == true));

            await _polkadotService.CloseAsync(CancellationToken.None);

            Assert.That(_polkadotService.AjunaClient.IsConnected, Is.False);
            Assert.That(_polkadotService.ChainDependencies.All(x => x.IsConnected() == false));
        }

        [Test]
        public async Task Connect_ShouldTriggerEventForPolkadotAndDependenciesAsync()
        {
            var onConnectionSetTriggered = new TaskCompletionSource<bool>();
            var onConnectionSetTriggeredForPeopleChain = new TaskCompletionSource<bool>();

            _polkadotService.AjunaClient.ConnectionSet += (sender, e) => onConnectionSetTriggered.SetResult(true);
            _polkadotService.ChainDependencies.First().AjunaClient.ConnectionSet += (sender, e) => onConnectionSetTriggeredForPeopleChain.SetResult(true);

            await _polkadotService.ConnectAsync(CancellationToken.None);

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

            _polkadotService.AjunaClient.ConnectionLost += (sender, e) => onConnectionLostTriggered.SetResult(true);
            _polkadotService.ChainDependencies.First().AjunaClient.ConnectionLost += (sender, e) => onConnectionLostTriggeredForPeopleChain.SetResult(true);

            await _polkadotService.ConnectAsync(CancellationToken.None);
            await _polkadotService.CloseAsync(CancellationToken.None);

            await Task.WhenAll(
                await Task.WhenAny(onConnectionLostTriggered.Task, Task.Delay(TimeSpan.FromMinutes(1))),
                await Task.WhenAny(onConnectionLostTriggeredForPeopleChain.Task, Task.Delay(TimeSpan.FromMinutes(1)))
            );

            Assert.That(onConnectionLostTriggered.Task.IsCompleted, Is.True);
            Assert.That(onConnectionLostTriggeredForPeopleChain.Task.IsCompleted, Is.True);
        }

        [Test]
        public async Task ManuallyDisconnect_ShouldNotTryToReconnectAsync()
        {
            await _polkadotService.ConnectAsync(CancellationToken.None);
            Assert.That(_polkadotService.IsConnected(), Is.True);
            
            await _polkadotService.CloseAsync(CancellationToken.None);
            Assert.That(_polkadotService.IsConnected(), Is.False);
        }

        [Test, Ignore("Todo debug already connected")]
        public async Task DisconnectedPrematurely_ShouldTryToReconnectAsync()
        {
            var onReconnectedTriggered = new TaskCompletionSource<(bool, int)>();
            _polkadotService.AjunaClient.OnReconnected += (sender, e) => onReconnectedTriggered.SetResult((true, e));

            await _polkadotService.ConnectAsync(CancellationToken.None);
            await _polkadotService.AjunaClient._socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);

            await Task.WhenAny(onReconnectedTriggered.Task, Task.Delay(TimeSpan.FromMinutes(1)));

            Assert.That(_polkadotService.AjunaClient.IsConnected, Is.True);
        }

        
    }
}
