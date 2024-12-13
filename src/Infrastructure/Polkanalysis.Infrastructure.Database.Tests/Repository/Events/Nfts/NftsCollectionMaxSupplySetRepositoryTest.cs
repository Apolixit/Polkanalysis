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
    public class NftsCollectionMaxSupplySetRepositoryTest : EventsDatabaseTests
    {
        private NftsCollectionMaxSupplySetRepository _nftsCollectionMaxSupplySetRepository;

        [SetUp]
        public void Setup()
        {
            _nftsCollectionMaxSupplySetRepository = new NftsCollectionMaxSupplySetRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsCollectionMaxSupplySetRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsCollectionMaxSupplySet.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "CollectionMaxSupplySet", 10, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsCollectionMaxSupplySetRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, 20)]
        public async Task BuildModel_WhenValidCollectionMaxSupplySet_ShouldBuildModelSuccessfullyAsync(double collection, double max_supply, double expected1)
        {
            var enumCollectionMaxSupplySet = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumCollectionMaxSupplySet.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.CollectionMaxSupplySet,
                    new BaseTuple<IncrementableU256, U128>(
                        new IncrementableU256(collection), new U128(new BigInteger(max_supply))
                        )

            );

            var model = await _nftsCollectionMaxSupplySetRepository.BuildModelAsync(
                BuildEventModel("Nfts", "CollectionMaxSupplySet"),
                enumCollectionMaxSupplySet,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("CollectionMaxSupplySet"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Max_supply, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsCollectionMaxSupplySetRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Max_supply = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
