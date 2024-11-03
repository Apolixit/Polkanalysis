using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.PeopleChain
{
    internal class PeopleChainIntegrationTests : InfrastructureIntegrationTest
    {
        internal PeopleChainIntegrationTests()
        {
            _substrateService = new PeopleChainService(
                    _substrateEndpoints,
                    new PeopleChainMapping(Substitute.For<ILogger<PeopleChainMapping>>()),
                    Substitute.For<ILogger<PeopleChainService>>()
                    );
        }

        [SetUp]
        protected void Setup()
        {
            // Just clean blockhash everytime
            _substrateService.Storage.BlockHash = null;
        }

        public static IEnumerable<int> AllBlockVersionTestCases = new List<int>()
        {
            1, 100000, 490000, 637704
        };
    }
}
