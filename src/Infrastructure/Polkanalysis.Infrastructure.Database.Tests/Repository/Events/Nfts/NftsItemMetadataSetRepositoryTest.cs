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
    public class NftsItemMetadataSetRepositoryTest : EventsDatabaseTests
    {
        private NftsItemMetadataSetRepository _nftsItemMetadataSetRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemMetadataSetRepository = new NftsItemMetadataSetRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsItemMetadataSetRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemMetadataSet.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemMetadataSet", 10, MockItemNft, MockMetadataNft));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemMetadataSetRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockItemNft, "test data 2", MockItemNft)]
        public async Task BuildModel_WhenValidItemMetadataSet_ShouldBuildModelSuccessfullyAsync(double collection, string item, string data, string expected1)
        {
            var enumItemMetadataSet = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemMetadataSet.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemMetadataSet,
                    new BaseTuple<IncrementableU256, U128, BaseVec<U8>>(
                        new IncrementableU256(collection), new U128(BigInteger.Parse(item)), new BaseVec<U8>(Encoding.ASCII.GetBytes(data).Select(x => new U8(x)).ToArray())
                        )

            );

            var model = await _nftsItemMetadataSetRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemMetadataSet"),
                enumItemMetadataSet,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemMetadataSet"));
            Assert.That(model.Collection, Is.EqualTo(collection));
            Assert.That(model.Data, Is.EqualTo(data));
            Assert.That(model.ItemValue(), Is.EqualTo(BigInteger.Parse(expected1)));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemMetadataSetRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
                Item = MockItemNft,
                Data = MockMetadataNft
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
