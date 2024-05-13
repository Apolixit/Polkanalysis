using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Auctions
{
    internal class AuctionClosedRepositoryTest : EventsDatabaseTests
    {
        private AuctionClosedRepository _auctionClosedRepository;

        [SetUp]
        public void Setup()
        {
            _auctionClosedRepository = new AuctionClosedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<AuctionClosedRepository>>());
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_auctionClosedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(10)]
        public async Task BuildModel_WhenValidAuctionClosed_ShouldBuildModelSuccessfullyAsync(int auctionIndex)
        {
            var enumContribution = new Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent();
            enumContribution.Create(Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.Event.AuctionClosed, new Id((uint)auctionIndex));

            var model = await _auctionClosedRepository.BuildModelAsync(
                BuildEventModel("Auction", moduleEvent: "Closed"),
                enumContribution,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Auction"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Closed"));
            Assert.That(model.AuctionIndex, Is.EqualTo(auctionIndex));
        }
    }
}
