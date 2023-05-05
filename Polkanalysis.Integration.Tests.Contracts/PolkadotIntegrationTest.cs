using Polkanalysis.Configuration.Contracts;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Integration.Tests.Contracts
{
    public abstract class PolkadotIntegrationTest : IntegrationTest
    {
        protected override ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfigurationMock = Substitute.For<ISubstrateEndpoint>();

            substrateConfigurationMock.BlockchainName.Returns("Polkadot");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri("wss://rpc.polkadot.io"));

            return substrateConfigurationMock;
        }
    }
}
