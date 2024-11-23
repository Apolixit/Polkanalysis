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
    public class NftsItemTransferLockedRepositoryTest : EventsDatabaseTests
    {
        private NftsItemTransferLockedRepository _nftsItemTransferLockedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemTransferLockedRepository = new NftsItemTransferLockedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsItemTransferLockedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemTransferLocked.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemTransferLocked", 10, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemTransferLockedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, 20)]
        public async Task BuildModel_WhenValidItemTransferLocked_ShouldBuildModelSuccessfullyAsync(double collection, double item, double expected1)
        {
            var enumItemTransferLocked = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemTransferLocked.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemTransferLocked,
                    new BaseTuple<IncrementableU256, U128>(
                        new IncrementableU256(collection), new U128(new BigInteger(item))
                        )

            );

            var model = await _nftsItemTransferLockedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemTransferLocked"),
                enumItemTransferLocked,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemTransferLocked"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Item, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemTransferLockedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
