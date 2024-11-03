using Polkanalysis.Domain.Contracts.Secondary;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Abstract.Tests;

namespace Polkanalysis.Domain.Integration.Tests
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class DomainIntegrationTest : GlobalIntegrationTest
    {
        /// <summary>
        /// A repository doesn't exceed <see cref="RepositoryMaxTimeout"/> millisecond to respond
        /// </summary>
        public const int RepositoryMaxTimeout = 5000;

        protected DomainIntegrationTest() : base()
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