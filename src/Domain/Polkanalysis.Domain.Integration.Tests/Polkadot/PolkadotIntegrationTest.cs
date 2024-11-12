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
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Integration.Tests.Polkadot
{
    public class PolkadotIntegrationTest : DomainIntegrationTest
    {
        private PeopleChainService _peopleChainService = default!;
        protected DelegateSystemChain _delegateSystemChain = default!;

        protected PolkadotIntegrationTest() : base()
        {
        }

        protected override ISubstrateService MockSubstrateService()
        {
            var peopleChainIntegrationTest = new PeopleChainIntegrationTest();

            return new PolkadotService(
                    _substrateEndpoints,
                    new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>()),
                    Substitute.For<ILogger<PolkadotService>>(),
                    (PeopleChainService)peopleChainIntegrationTest.GetSubstrateService(),
                    _serviceProvider);
        }

        [OneTimeSetUp]
        protected void SetupBase()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;
            _substrateDbContext = new SubstrateDbContext(contextOption);

            _delegateSystemChain = new DelegateSystemChain(_substrateService, _substrateDbContext, Substitute.For<ILogger<DelegateSystemChain>>());
            _serviceProvider.GetService(typeof(IDelegateSystemChain)).Returns(_delegateSystemChain);

            _substrateDbContext.TokenPrices.Add(new Infrastructure.Database.Contracts.Model.Price.TokenPriceModel()
            {
                BlockchainName = "Polkadot",
                Date = new DateTime(2024, 01, 01),
                Price = 10
            });

            _substrateDbContext.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }
    }
}
