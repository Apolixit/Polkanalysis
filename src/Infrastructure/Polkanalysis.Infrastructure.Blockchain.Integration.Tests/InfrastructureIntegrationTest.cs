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

        protected InfrastructureIntegrationTest() : base()
        {
        }
    }
}