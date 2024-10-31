using Polkanalysis.Configuration.Contracts;
using NSubstitute;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Domain.Integration.Tests.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

namespace Polkanalysis.Domain.Integration.Tests.Polkadot
{
    public abstract class PolkadotIntegrationTest : IntegrationTest
    {
        protected SubstrateDbContext _substrateDbContext;
        private PeopleChainService _peopleChainService = default!;

        protected PolkadotIntegrationTest()
        {
            var peopleChainIntegrationTest = new PeopleChainIntegrationTest();
            _peopleChainService = new PeopleChainService(
                peopleChainIntegrationTest.GetEndpoint(), 
                new PeopleChainMapping(Substitute.For<ILogger<PeopleChainMapping>>()),
                Substitute.For<ILogger<PeopleChainService>>());

            _substrateService = new PolkadotService(
                    _substrateEndpoint,
                    new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>()),
                    Substitute.For<ILogger<PolkadotService>>(),
                    _peopleChainService);
        }

        public string PolkadotEndpointUri => "wss://dot-rpc.stakeworld.io";
        internal override ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfigurationMock = Substitute.For<ISubstrateEndpoint>();

            substrateConfigurationMock.BlockchainName.Returns("Polkadot");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri(PolkadotEndpointUri));

            return substrateConfigurationMock;
        }

        //public async override Task ConnectDependenciesAsync()
        //{
        //    await _peopleChainService.ConnectAsync();
        //}

        [SetUp]
        protected void SetupBase()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;
            _substrateDbContext = new SubstrateDbContext(contextOption);

            _substrateDbContext.TokenPrices.Add(new Infrastructure.Database.Contracts.Model.Price.TokenPriceModel()
            {
                BlockchainName = "Polkadot",
                Date = new DateTime(2024, 01, 01),
                Price = 10
            });

            _substrateDbContext.SaveChanges();
        }

        [TearDown]
        public void TearDownBase()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }
    }
}
