using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.PeopleChain
{
    internal class PeopleChainIntegrationTests : IntegrationTest
    {
        internal PeopleChainIntegrationTests()
        {
            _substrateRepository = new PeopleChainService(
                    _substrateEndpoint,
                    new PeopleChainMapping(Substitute.For<ILogger>()),
                    Substitute.For<ILogger<PeopleChainService>>()
                    );
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

            substrateConfigurationMock.BlockchainName.Returns("PeopleChain");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri("wss://rpc-people-polkadot.luckyfriday.io"));

            return substrateConfigurationMock;
        }
    }
}
