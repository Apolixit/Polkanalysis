using Ajuna.NetApi.Model.Extrinsics;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Polkadot.Repository;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Runtime;

namespace Polkanalysis.Integration.Tests.Contracts
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class IntegrationTest
    {
        //protected readonly ISubstrateClientRepository _substrateClientRepository;
        protected readonly ISubstrateRepository _substrateRepository;
        protected ISubstrateEndpoint _substrateEndpoint;

        protected IntegrationTest()
        {
            _substrateEndpoint = GetEndpoint();

            if (_substrateEndpoint == null)
                throw new InvalidOperationException($"{nameof(_substrateEndpoint)} is null. You must provide a valid Substrate endpoint");

            _substrateRepository = new PolkadotRepository(
                _substrateEndpoint,
                Substitute.For<ILogger<PolkadotRepository>>()
                );
            //_substrateRepository = Substitute.For<ISubstrateRepository>();
            //_substrateRepository.IsValidAccountAddress(Arg.Any<string>()).Returns(true);

            //_substrateClientRepository = new PolkadotSubstrateClientRepository(_substrateEndpoint);
            //_substrateRepository.Api.Returns(_substrateClientRepository);
        }

        protected abstract ISubstrateEndpoint GetEndpoint();

        /// <summary>
        /// Connect to the endpoint at the beggining of test
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp]
        public virtual async Task ConnectAsync()
        {
            if (_substrateRepository != null && !_substrateRepository.IsConnected())
            {
                try
                {
                    await _substrateRepository.ConnectAsync();
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
            if (_substrateRepository != null && _substrateRepository.IsConnected())
            {
                await _substrateRepository.CloseAsync();
            }
        }
    }
}