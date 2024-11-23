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
    public class NftsItemPriceRemovedRepositoryTest : EventsDatabaseTests
    {
        private NftsItemPriceRemovedRepository _nftsItemPriceRemovedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemPriceRemovedRepository = new NftsItemPriceRemovedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsItemPriceRemovedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemPriceRemoved.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemPriceRemoved", 10, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemPriceRemovedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, 20)]
        public async Task BuildModel_WhenValidItemPriceRemoved_ShouldBuildModelSuccessfullyAsync(double collection, double item, double expected1)
        {
            var enumItemPriceRemoved = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemPriceRemoved.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemPriceRemoved,
                    new BaseTuple<IncrementableU256, U128>(
                        new IncrementableU256(collection), new U128(new BigInteger(item))
                        )

            );

            var model = await _nftsItemPriceRemovedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemPriceRemoved"),
                enumItemPriceRemoved,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemPriceRemoved"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Item, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemPriceRemovedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
