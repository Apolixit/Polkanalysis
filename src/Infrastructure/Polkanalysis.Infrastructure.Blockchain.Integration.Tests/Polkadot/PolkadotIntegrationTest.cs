using Polkanalysis.Configuration.Contracts;
using NSubstitute;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
using Polkanalysis.Infrastructure.Blockchain.Integration.Tests.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot
{
    public class PolkadotIntegrationTest : IntegrationTest
    {
        private PeopleChainService _peopleChainService = default!;

        protected PolkadotIntegrationTest()
        {
            var peopleChainIntegration = new PeopleChainIntegrationTests();
            _peopleChainService = new PeopleChainService(
                    peopleChainIntegration.GetEndpoint(),
                    new PeopleChainMapping(Substitute.For<ILogger<PeopleChainMapping>>()),
                    Substitute.For<ILogger<PeopleChainService>>()
                    );

            _substrateRepository = new PolkadotService(
                    _substrateEndpoint,
                    new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>()),
                    Substitute.For<ILogger<PolkadotService>>(),
                    _peopleChainService);
        }

        [SetUp]
        protected void Setup()
        {
            // Just clean blockhash everytime
            _substrateRepository.Storage.BlockHash = null;
        }

        internal override ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfigurationMock = Substitute.For<ISubstrateEndpoint>();

            substrateConfigurationMock.BlockchainName.Returns("Polkadot");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri("wss://dot-rpc.stakeworld.io"));

            return substrateConfigurationMock;
        }

        protected async Task<string> GetBlockHashAsync(int blockNum)
        {
            var res = await _substrateRepository.AjunaClient.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber((uint)blockNum));
            return res.Value;
        }

        //public static IEnumerable<int> AllBlockVersionTestCases = new List<int>()
        //{
        //    16500000
        //};

        public static IEnumerable<int> AllBlockVersionTestCases = new List<int>()
        {
            1, 29232, 188837, 199406, 214265, 244359, 310000, 320000, 400000, 500000, 600000, 700000, 750000, 790000, 800000, 1300000, 1700000, 1800000, 2400000, 2500000, 3700000, 3900000, 4500000, 5000000, 6000000, 6500000, 7000000, 7220000, 7500000, 8000000, 8500000, 9000000, 9500000, 10000000, 10200000, 10500000, 10700000, 10900000, 11500000, 11900000, 12000000, 12220000, 12400000, 12800000, 13000000, 13900000, 14400000, 15400000, 16400000, 16500000, 17907450, 18794175, 20029640, 20215034, 20443970, 21318590, 21460214, 21562434, 22422694, 22593936
        };

        /// <summary>
        /// Start from SpecVersion = 26 (block 2500000)
        /// </summary>
        public static IEnumerable<int> BlockFromVersion26 => AllBlockVersionTestCases.Skip(19);
        public static IEnumerable<int> BlockFromVersion9090 => AllBlockVersionTestCases.Skip(26);
        public static IEnumerable<int> BlockFromVersion9340 => AllBlockVersionTestCases.Skip(45);

        public static IEnumerable<int> BlockFromLast10Versions => AllBlockVersionTestCases.Skip(AllBlockVersionTestCases.Count() - 10);
    }
}
