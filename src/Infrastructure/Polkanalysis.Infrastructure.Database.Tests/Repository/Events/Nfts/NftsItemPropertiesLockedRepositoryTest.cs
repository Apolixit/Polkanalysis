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
    public class NftsItemPropertiesLockedRepositoryTest : EventsDatabaseTests
    {
        private NftsItemPropertiesLockedRepository _nftsItemPropertiesLockedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemPropertiesLockedRepository = new NftsItemPropertiesLockedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsItemPropertiesLockedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemPropertiesLocked.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemPropertiesLocked", 10, 20, true, false));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemPropertiesLockedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, true, false, 20)]
        public async Task BuildModel_WhenValidItemPropertiesLocked_ShouldBuildModelSuccessfullyAsync(double collection, double item, bool lock_metadata, bool lock_attributes, double expected1)
        {
            var enumItemPropertiesLocked = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemPropertiesLocked.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemPropertiesLocked,
                    new BaseTuple<IncrementableU256, U128, Bool, Bool>(
                        new IncrementableU256(collection), new U128(new BigInteger(item)), new Bool(lock_metadata), new Bool(lock_attributes)
                        )

            );

            var model = await _nftsItemPropertiesLockedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemPropertiesLocked"),
                enumItemPropertiesLocked,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemPropertiesLocked"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Lock_metadata, Is.EqualTo(lock_metadata));
Assert.That(model.Lock_attributes, Is.EqualTo(lock_attributes));
Assert.That(model.Item, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemPropertiesLockedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20),
				Lock_metadata = true,
				Lock_attributes = false
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
