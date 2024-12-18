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
    public class NftsCollectionMetadataSetRepositoryTest : EventsDatabaseTests
    {
        private NftsCollectionMetadataSetRepository _nftsCollectionMetadataSetRepository;

        [SetUp]
        public void Setup()
        {
            _nftsCollectionMetadataSetRepository = new NftsCollectionMetadataSetRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsCollectionMetadataSetRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsCollectionMetadataSet.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "CollectionMetadataSet", 10, MockMetadataNft));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsCollectionMetadataSetRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, "test data 2")]
        public async Task BuildModel_WhenValidCollectionMetadataSet_ShouldBuildModelSuccessfullyAsync(double collection, string data)
        {
            var enumCollectionMetadataSet = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumCollectionMetadataSet.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMetadataSet,
                    new BaseTuple<IncrementableU256, BaseVec<U8>>(
                        new IncrementableU256(collection), new BaseVec<U8>(Encoding.ASCII.GetBytes(data).Select(x => new U8(x)).ToArray())
                        )

            );

            var model = await _nftsCollectionMetadataSetRepository.BuildModelAsync(
                BuildEventModel("Nfts", "CollectionMetadataSet"),
                enumCollectionMetadataSet,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("CollectionMetadataSet"));
            Assert.That(model.Collection, Is.EqualTo(collection));
            Assert.That(model.Data, Is.EqualTo(data));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsCollectionMetadataSetRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
                Data = MockMetadataNft
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
