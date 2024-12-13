using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Nfts;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;
using Substrate.NET.Utils;
using Polkanalysis.Hub;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Nfts
{
    public class NftsTipSentRepositoryTest : EventsDatabaseTests
    {
        private NftsTipSentRepository _nftsTipSentRepository;

        [SetUp]
        public void Setup()
        {
            _nftsTipSentRepository = new NftsTipSentRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsTipSentRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsTipSent.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "TipSent", 10, MockItemNft, Charlie.ToString(), Dave.ToString(), 50));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsTipSentRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockItemNft, MockAddress3, MockAddress4, 500_000_000_000, MockItemNft, 50)]
        public async Task BuildModel_WhenValidTipSent_ShouldBuildModelSuccessfullyAsync(double collection, string item, string sender, string receiver, double amount, string expected1, double expected2)
        {
            var bt = new BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount, U128>();
            bt.Create(new IncrementableU256(collection), new U128(BigInteger.Parse(item)), new SubstrateAccount(sender), new SubstrateAccount(receiver), new U128(new BigInteger(amount)));

            var enumTipSent = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumTipSent.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.TipSent, bt);

            var model = await _nftsTipSentRepository.BuildModelAsync(
                BuildEventModel("Nfts", "TipSent"),
                enumTipSent,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("TipSent"));
            Assert.That(model.Collection, Is.EqualTo(collection));
            Assert.That(model.Sender, Is.EqualTo(sender));
            Assert.That(model.Receiver, Is.EqualTo(receiver));
            Assert.That(model.ItemValue(), Is.EqualTo(BigInteger.Parse(expected1)));
            Assert.That(model.Amount, Is.EqualTo(expected2));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsTipSentRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
                Item = MockItemNft,
                Sender = Charlie.ToString(),
                Receiver = Dave.ToString(),
                Amount = NumberCriteria<double>.Equal(50)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
