using Polkanalysis.Domain.Contracts.Secondary;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Integration.Tests
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class IntegrationTest
    {
        protected ISubstrateService _substrateService;
        protected ISubstrateEndpoint _substrateEndpoint;

        /// <summary>
        /// A repository doesn't exceed <see cref="RepositoryMaxTimeout"/> millisecond to respond
        /// </summary>
        public const int RepositoryMaxTimeout = 5000;

        protected IntegrationTest()
        {
            _substrateEndpoint = GetEndpoint();

            if (_substrateEndpoint == null)
                throw new InvalidOperationException($"{nameof(_substrateEndpoint)} is null. You must provide a valid Substrate endpoint");
        }

        protected abstract ISubstrateEndpoint GetEndpoint();

        /// <summary>
        /// Connect to the endpoint at the beggining of test
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp]
        public virtual async Task ConnectAsync()
        {
            if (_substrateService != null && !_substrateService.IsConnected())
            {
                try
                {
                    await _substrateService.ConnectAsync();
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
            if (_substrateService != null && _substrateService.IsConnected())
            {
                await _substrateService.CloseAsync();
            }
        }
    }
}