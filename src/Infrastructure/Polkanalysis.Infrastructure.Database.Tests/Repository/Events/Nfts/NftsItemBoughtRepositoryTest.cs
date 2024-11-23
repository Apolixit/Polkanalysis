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

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Nfts
{
    public class NftsItemBoughtRepositoryTest : EventsDatabaseTests
    {
        private NftsItemBoughtRepository _nftsItemBoughtRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemBoughtRepository = new NftsItemBoughtRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsItemBoughtRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemBought.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemBought", 10, 20, 30, Dave.ToString(), Eve.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemBoughtRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, 300_000_000_000, MockAddress4, MockAddress5, 20, 30)]
        public async Task BuildModel_WhenValidItemBought_ShouldBuildModelSuccessfullyAsync(double collection, double item, double price, string seller, string buyer, double expected1, double expected2)
        {
            var bt = new BaseTuple<IncrementableU256, U128, U128, SubstrateAccount, SubstrateAccount>();
            bt.Create(new IncrementableU256(collection), new U128(new BigInteger(item)), new U128(new BigInteger(price)), new SubstrateAccount(seller), new SubstrateAccount(buyer));
            var enumItemBought = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemBought.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemBought, bt);

            var model = await _nftsItemBoughtRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemBought"),
                enumItemBought,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemBought"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Seller, Is.EqualTo(seller));
Assert.That(model.Buyer, Is.EqualTo(buyer));
Assert.That(model.Item, Is.EqualTo(expected1));
				Assert.That(model.Price, Is.EqualTo(expected2));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemBoughtRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20),
				Price = NumberCriteria<double>.Equal(30),
				Seller = Dave.ToString(),
				Buyer = Eve.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
