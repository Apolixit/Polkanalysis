using Polkanalysis.Configuration.Contracts;
using NSubstitute;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;

namespace Polkanalysis.Domain.Integration.Tests.Polkadot
{
    public abstract class PolkadotIntegrationTest : IntegrationTest
    {
        protected PolkadotIntegrationTest()
        {
            _substrateRepository = new PolkadotService(
                    _substrateEndpoint,
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
    }
}
