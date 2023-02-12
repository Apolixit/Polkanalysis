using Ajuna.NetApi.Model.Extrinsics;
using Substats.Configuration.Contracts;
using Substats.Domain.Contracts.Secondary;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using Substats.Infrastructure.Polkadot.Repository;

namespace Substats.Integration.Tests.Contracts
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class IntegrationTest
    {
        protected readonly ISubstrateClientRepository _substrateClientRepository;
        protected readonly ISubstrateRepository _substrateRepository;
        protected ISubstrateEndpoint _substrateEndpoint;

        protected IntegrationTest()
        {
            _substrateEndpoint = GetEndpoint();

            if (_substrateEndpoint == null)
                throw new InvalidOperationException($"{nameof(_substrateEndpoint)} is null. You must provide a valid Substrate endpoint");

            _substrateRepository = Substitute.For<ISubstrateRepository>();
            _substrateRepository.IsValidAccountAddress(Arg.Any<string>()).Returns(true);

            _substrateClientRepository = new PolkadotSubstrateClientRepository(_substrateEndpoint);
            _substrateRepository.Api.Returns(_substrateClientRepository);
        }

        protected abstract ISubstrateEndpoint GetEndpoint();

        /// <summary>
        /// Connect to the endpoint at the beggining of test
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp]
        public virtual async Task ConnectAsync()
        {
            if (_substrateRepository.Api != null && !_substrateRepository.Api.Core.IsConnected)
            {
                try
                {
                    await _substrateRepository.Api.Core.ConnectAsync();
                }
                catch (Exception)
                {
                    Assert.Ignore("Substrate node is not currently running. All tests are ignore.");
                }
            }
        }

        /// <summary>
        /// Close connection when tests are finished
        /// </summary>
        /// <returns></returns>
        [OneTimeTearDown]
        public virtual async Task DisconnectAsync()
        {
            if (_substrateRepository.Api != null && _substrateRepository.Api.Core.IsConnected)
            {
                await _substrateRepository.Api.Core.CloseAsync();
            }
        }
    }
}