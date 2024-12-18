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
    public class NftsItemMetadataClearedRepositoryTest : EventsDatabaseTests
    {
        private NftsItemMetadataClearedRepository _nftsItemMetadataClearedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemMetadataClearedRepository = new NftsItemMetadataClearedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsItemMetadataClearedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemMetadataCleared.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemMetadataCleared", 10, MockItemNft));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemMetadataClearedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockItemNft, MockItemNft)]
        public async Task BuildModel_WhenValidItemMetadataCleared_ShouldBuildModelSuccessfullyAsync(double collection, string item, string expected1)
        {
            var enumItemMetadataCleared = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemMetadataCleared.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemMetadataCleared,
                    new BaseTuple<IncrementableU256, U128>(
                        new IncrementableU256(collection), new U128(BigInteger.Parse(item))
                        )

            );

            var model = await _nftsItemMetadataClearedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemMetadataCleared"),
                enumItemMetadataCleared,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemMetadataCleared"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.ItemValue(), Is.EqualTo(BigInteger.Parse(expected1)));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemMetadataClearedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = MockItemNft,
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
