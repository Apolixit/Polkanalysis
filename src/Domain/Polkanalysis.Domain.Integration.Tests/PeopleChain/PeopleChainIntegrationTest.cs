using NSubstitute;
using Polkanalysis.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Integration.Tests.PeopleChain
{
    public class PeopleChainIntegrationTest : IntegrationTest
    {
        public string PeopleChainEndpointUri => "wss://rpc-people-polkadot.luckyfriday.io";

        internal override ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfigurationMock = Substitute.For<ISubstrateEndpoint>();

            substrateConfigurationMock.BlockchainName.Returns("PeopleChain");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri(PeopleChainEndpointUri));

            return substrateConfigurationMock;
        }
    }
}
