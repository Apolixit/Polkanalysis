using Polkanalysis.Domain.Contracts.Secondary;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class IntegrationTest
    {
        protected ISubstrateService _substrateRepository = default!;
        protected ISubstrateEndpoint _substrateEndpoint = default!;

        protected const string NoTestCase = "NO TEST CASE";
        /// <summary>
        /// A repository doesn't exceed <see cref="RepositoryMaxTimeout"/> millisecond to respond
        /// </summary>
        public const int RepositoryMaxTimeout = 2000;

        protected IntegrationTest()
        {
            _substrateEndpoint = GetEndpoint();

            if (_substrateEndpoint == null)
                throw new InvalidOperationException($"{nameof(_substrateEndpoint)} is null. You must provide a valid Substrate endpoint");
        }

        internal abstract ISubstrateEndpoint GetEndpoint();

        public abstract Task ConnectDependenciesAsync();

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
                    await ConnectDependenciesAsync();
                }
                catch (Exception ex)
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