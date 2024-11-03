using Polkanalysis.Domain.Contracts.Secondary;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Abstract.Tests;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class InfrastructureIntegrationTest : GlobalIntegrationTest
    {
        protected const string NoTestCase = "NO TEST CASE";
        /// <summary>
        /// A repository doesn't exceed <see cref="RepositoryMaxTimeout"/> millisecond to respond
        /// </summary>
        public const int RepositoryMaxTimeout = 2000;

        protected InfrastructureIntegrationTest()
        {
        }

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
                    await _substrateService.ConnectAsync(CancellationToken.None);
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
                await _substrateService.CloseAsync(CancellationToken.None);
            }
        }
    }
}