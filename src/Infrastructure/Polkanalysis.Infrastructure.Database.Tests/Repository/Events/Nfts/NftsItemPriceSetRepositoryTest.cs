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
    public class NftsItemPriceSetRepositoryTest : EventsDatabaseTests
    {
        private NftsItemPriceSetRepository _nftsItemPriceSetRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemPriceSetRepository = new NftsItemPriceSetRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsItemPriceSetRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemPriceSet.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemPriceSet", 10, 20, 30, Dave.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemPriceSetRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, 300_000_000_000, MockAddress4, 20, 30)]
        public async Task BuildModel_WhenValidItemPriceSet_ShouldBuildModelSuccessfullyAsync(double collection, double item, double price, string? whitelisted_buyer, double expected1, double expected2)
        {
            var enumItemPriceSet = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemPriceSet.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemPriceSet,
                    new BaseTuple<IncrementableU256, U128, U128, BaseOpt<SubstrateAccount>>(
                        new IncrementableU256(collection), new U128(new BigInteger(item)), new U128(new BigInteger(price)), new BaseOpt<SubstrateAccount>(new SubstrateAccount(whitelisted_buyer))
                        )

            );

            var model = await _nftsItemPriceSetRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemPriceSet"),
                enumItemPriceSet,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemPriceSet"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Whitelisted_buyer, Is.EqualTo(whitelisted_buyer));
Assert.That(model.Item, Is.EqualTo(expected1));
				Assert.That(model.Price, Is.EqualTo(expected2));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemPriceSetRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20),
				Price = NumberCriteria<double>.Equal(30),
				Whitelisted_buyer = Dave.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
