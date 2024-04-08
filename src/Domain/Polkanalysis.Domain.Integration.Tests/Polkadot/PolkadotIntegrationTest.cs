using Polkanalysis.Configuration.Contracts;
using NSubstitute;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database;
using NUnit.Framework;

namespace Polkanalysis.Domain.Integration.Tests.Polkadot
{
    public abstract class PolkadotIntegrationTest : IntegrationTest
    {
        protected SubstrateDbContext _substrateDbContext;

        protected PolkadotIntegrationTest()
        {
            _substrateService = new PolkadotService(
                    _substrateEndpoint,
                    new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>()),
                    Substitute.For<ILogger<PolkadotService>>()
                    );
        }

        protected override ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfigurationMock = Substitute.For<ISubstrateEndpoint>();

            substrateConfigurationMock.BlockchainName.Returns("Polkadot");
            substrateConfigurationMock.WsEndpointUri.Returns(new Uri("wss://polkadot-rpc.dwellir.com"));

            return substrateConfigurationMock;
        }

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
