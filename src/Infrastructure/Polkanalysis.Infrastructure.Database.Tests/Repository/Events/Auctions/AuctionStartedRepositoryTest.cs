using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Hub;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Auctions
{
    internal class AuctionStartedRepositoryTest : EventsDatabaseTests
    {
        private AuctionsAuctionStartedRepository _auctionStartedRepository;

        [SetUp]
        public void Setup()
        {
            _auctionStartedRepository = new AuctionsAuctionStartedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<AuctionsAuctionStartedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventAuctionsAuctionStarted.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "Auctions", "Started", 1, 1, 1));
            _substrateDbContext.EventAuctionsAuctionStarted.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "Auctions", "Started", 2, 2, 2));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_auctionStartedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(10, 12, 10_000)]
        public async Task BuildModel_WhenValidAuctionClosed_ShouldBuildModelSuccessfullyAsync(int auctionIndex, int leasePeriod, int ending)
        {
            var enumContribution = new Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent();
            enumContribution.Create(Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.Event.AuctionStarted,
                new BaseTuple<U32, U32, U32>(
                    new U32((uint)auctionIndex),
                    new U32((uint)leasePeriod),
                    new U32((uint)ending)));

            var model = await _auctionStartedRepository.BuildModelAsync(
                BuildEventModel("Auction", moduleEvent: "Started"),
                enumContribution,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Auction"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Started"));
            Assert.That(model.AuctionIndex, Is.EqualTo(auctionIndex));
            Assert.That(model.LeasePeriod, Is.EqualTo(leasePeriod));
            Assert.That(model.Ending, Is.EqualTo(ending));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _auctionStartedRepository.SearchAsync(new SearchCriteriaAuctionsAuctionStarted()
            {
                AuctionIndex = NumberCriteria<uint>.GreaterThan(1)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
