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
    public class NftsCollectionMintSettingsUpdatedRepositoryTest : EventsDatabaseTests
    {
        private NftsCollectionMintSettingsUpdatedRepository _nftsCollectionMintSettingsUpdatedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsCollectionMintSettingsUpdatedRepository = new NftsCollectionMintSettingsUpdatedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsCollectionMintSettingsUpdatedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsCollectionMintSettingsUpdated.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "CollectionMintSettingsUpdated", 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsCollectionMintSettingsUpdatedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0)]
        public async Task BuildModel_WhenValidCollectionMintSettingsUpdated_ShouldBuildModelSuccessfullyAsync(double collection)
        {
            var enumCollectionMintSettingsUpdated = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumCollectionMintSettingsUpdated.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMintSettingsUpdated,
                        new IncrementableU256(collection)
            );

            var model = await _nftsCollectionMintSettingsUpdatedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "CollectionMintSettingsUpdated"),
                enumCollectionMintSettingsUpdated,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("CollectionMintSettingsUpdated"));
            Assert.That(model.Collection, Is.EqualTo(collection));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsCollectionMintSettingsUpdatedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
