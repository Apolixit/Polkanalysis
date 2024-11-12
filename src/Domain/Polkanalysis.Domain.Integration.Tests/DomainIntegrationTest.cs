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
    }
}