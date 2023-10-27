using Polkanalysis.Configuration.Contracts;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot
{
    public abstract class PolkadotIntegrationTest : IntegrationTest
    {
        protected PolkadotIntegrationTest()
        {
            _substrateRepository = new PolkadotService(
                    _substrateEndpoint,
                    new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>()),
                    Substitute.For<ILogger<PolkadotService>>()
                    );
        }

        protected override ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfigurationMock = Substitute.For<ISubstrateEndpoint>();

            substrateConfigurationMock.BlockchainName.Returns("Polkadot");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri("wss://rpc.polkadot.io"));

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
            7500000, 8000000, 8500000, 9000000, 9500000, 10000000, 10200000, 10500000, 10700000, 10900000, 11500000, 11900000, 12000000, 12220000, 12400000, 12800000, 13000000, 13900000, 14400000, 15400000, 16400000, 16500000
        };
    }
}
