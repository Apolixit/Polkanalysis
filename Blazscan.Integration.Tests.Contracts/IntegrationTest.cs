using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Configuration.Contract;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;

namespace Blazscan.Integration.Tests.Contracts
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class IntegrationTest
    {
        protected readonly ISubstrateNodeRepository _substrateRepository;
        protected readonly IConfiguration _configuration;
        protected SubstrateEndpoint _substrateEndpoint;

        public IntegrationTest()
        {
            _substrateEndpoint = GetEndpoint();

            if (_substrateEndpoint == null)
                throw new ArgumentNullException("You must provide a valid Substrate endpoint");

            _configuration = Substitute.For<IConfiguration>();
            //_substrateRepository = Substitute.For<ISubstrateNodeRepository>();

            //_substrateRepository.Client.Returns(new Polkadot.NetApiExt.Generated.SubstrateClientExt(
            //    _substrateEndpoint.EndPointUri, 
            //    ChargeTransactionPayment.Default()));
            // TODO : change
            //_substrateRepository.Returns(new SubstrateNodeRepositoryDirectAccess(_configuration));
            _substrateRepository = new SubstrateNodeRepositoryDirectAccess(_configuration);
        }

        protected abstract SubstrateEndpoint GetEndpoint();

        /// <summary>
        /// Connect to the endpoint at the beggining of test
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp]
        public virtual async Task ConnectAsync()
        {
            if (_substrateRepository.Client != null && !_substrateRepository.Client.IsConnected)
            {
                try
                {
                    await _substrateRepository.Client.ConnectAsync();
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
            if (_substrateRepository.Client != null && _substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.CloseAsync();
            }
        }
    }
}