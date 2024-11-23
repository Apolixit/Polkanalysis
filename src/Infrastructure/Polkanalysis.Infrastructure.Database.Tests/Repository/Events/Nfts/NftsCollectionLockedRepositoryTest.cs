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
    public class NftsCollectionLockedRepositoryTest : EventsDatabaseTests
    {
        private NftsCollectionLockedRepository _nftsCollectionLockedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsCollectionLockedRepository = new NftsCollectionLockedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsCollectionLockedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsCollectionLocked.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "CollectionLocked", 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsCollectionLockedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0)]
        public async Task BuildModel_WhenValidCollectionLocked_ShouldBuildModelSuccessfullyAsync(double collection)
        {
            var enumCollectionLocked = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumCollectionLocked.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionLocked, new IncrementableU256(collection));

            var model = await _nftsCollectionLockedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "CollectionLocked"),
                enumCollectionLocked,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("CollectionLocked"));
            Assert.That(model.Collection, Is.EqualTo(collection));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsCollectionLockedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
