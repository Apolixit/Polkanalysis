using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Auctions
{
    internal class AuctionClosedRepositoryTest : EventsDatabaseTests
    {
        private AuctionsAuctionClosedRepository _auctionClosedRepository;

        [SetUp]
        public void Setup()
        {
            _auctionClosedRepository = new AuctionsAuctionClosedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<AuctionsAuctionClosedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventAuctionsAuctionClosed.Add(new Contracts.Model.Events.Auctions.AuctionsAuctionClosedModel("Polkadot", 1, new DateTime(2024, 01, 01), 1, "Auctions", "Closed", 1));
            _substrateDbContext.EventAuctionsAuctionClosed.Add(new Contracts.Model.Events.Auctions.AuctionsAuctionClosedModel("Polkadot", 2, new DateTime(2024, 01, 01), 1, "Auctions", "Closed", 2));
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
            enumContribution.Create(Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.Event.AuctionClosed, new U32((uint)auctionIndex));

            var model = await _auctionClosedRepository.BuildModelAsync(
                BuildEventModel("Auction", moduleEvent: "Closed"),
                enumContribution,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Auction"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Closed"));
            Assert.That(model.AuctionIndex, Is.EqualTo(auctionIndex));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _auctionClosedRepository.SearchAsync(new SearchCriteriaAuctionsAuctionClosed()
            {
                AuctionIndex = NumberCriteria<uint>.Equal(1)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
