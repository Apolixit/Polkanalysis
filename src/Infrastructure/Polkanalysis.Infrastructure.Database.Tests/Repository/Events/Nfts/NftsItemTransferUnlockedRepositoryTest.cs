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
    public class NftsItemTransferUnlockedRepositoryTest : EventsDatabaseTests
    {
        private NftsItemTransferUnlockedRepository _nftsItemTransferUnlockedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemTransferUnlockedRepository = new NftsItemTransferUnlockedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsItemTransferUnlockedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemTransferUnlocked.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemTransferUnlocked", 10, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemTransferUnlockedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, 20)]
        public async Task BuildModel_WhenValidItemTransferUnlocked_ShouldBuildModelSuccessfullyAsync(double collection, double item, double expected1)
        {
            var enumItemTransferUnlocked = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemTransferUnlocked.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemTransferUnlocked,
                    new BaseTuple<IncrementableU256, U128>(
                        new IncrementableU256(collection), new U128(new BigInteger(item))
                        )

            );

            var model = await _nftsItemTransferUnlockedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemTransferUnlocked"),
                enumItemTransferUnlocked,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemTransferUnlocked"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Item, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemTransferUnlockedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
