using Microsoft.EntityFrameworkCore;
using Polkanalysis.Abstract.Tests;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Domain.Tests.Abstract
{
    public abstract class DomainTestAbstract : GlobalAbstractTest
    {
        protected SubstrateDbContext _substrateDbContext;

        [SetUp]
        protected void DomainTestAbstractSetup()
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
        public void TearDown()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }
    }
}
