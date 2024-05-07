using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Auctions
{
    internal class AuctionStartedRepositoryTest : EventsDatabaseTests
    {
        private AuctionStartedRepository _auctionStartedRepository;

        [SetUp]
        public void Setup()
        {
            _auctionStartedRepository = new AuctionStartedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IBlockchainMapping>(),
                Substitute.For<ILogger<AuctionStartedRepository>>());
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
    }
}
