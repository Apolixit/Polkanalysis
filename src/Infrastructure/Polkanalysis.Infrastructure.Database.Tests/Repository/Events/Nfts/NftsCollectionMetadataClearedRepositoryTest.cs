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
using Polkanalysis.Hub;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Nfts
{
    public class NftsCollectionMetadataClearedRepositoryTest : EventsDatabaseTests
    {
        private NftsCollectionMetadataClearedRepository _nftsCollectionMetadataClearedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsCollectionMetadataClearedRepository = new NftsCollectionMetadataClearedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsCollectionMetadataClearedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsCollectionMetadataCleared.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "CollectionMetadataCleared", 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsCollectionMetadataClearedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0)]
        public async Task BuildModel_WhenValidCollectionMetadataCleared_ShouldBuildModelSuccessfullyAsync(double collection)
        {
            var enumCollectionMetadataCleared = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumCollectionMetadataCleared.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMetadataCleared, new IncrementableU256(collection));

            var model = await _nftsCollectionMetadataClearedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "CollectionMetadataCleared"),
                enumCollectionMetadataCleared,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("CollectionMetadataCleared"));
            Assert.That(model.Collection, Is.EqualTo(collection));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsCollectionMetadataClearedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
