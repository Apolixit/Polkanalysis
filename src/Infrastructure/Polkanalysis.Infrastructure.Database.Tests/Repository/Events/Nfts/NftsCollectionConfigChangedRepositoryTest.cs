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
    public class NftsCollectionConfigChangedRepositoryTest : EventsDatabaseTests
    {
        private NftsCollectionConfigChangedRepository _nftsCollectionConfigChangedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsCollectionConfigChangedRepository = new NftsCollectionConfigChangedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsCollectionConfigChangedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsCollectionConfigChanged.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "CollectionConfigChanged", 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsCollectionConfigChangedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0)]
        public async Task BuildModel_WhenValidCollectionConfigChanged_ShouldBuildModelSuccessfullyAsync(double collection)
        {
            var enumCollectionConfigChanged = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumCollectionConfigChanged.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionConfigChanged, new IncrementableU256(collection));

            var model = await _nftsCollectionConfigChangedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "CollectionConfigChanged"),
                enumCollectionConfigChanged,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("CollectionConfigChanged"));
            Assert.That(model.Collection, Is.EqualTo(collection));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsCollectionConfigChangedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
