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
    public class NftsNextCollectionIdIncrementedRepositoryTest : EventsDatabaseTests
    {
        private NftsNextCollectionIdIncrementedRepository _nftsNextCollectionIdIncrementedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsNextCollectionIdIncrementedRepository = new NftsNextCollectionIdIncrementedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsNextCollectionIdIncrementedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsNextCollectionIdIncremented.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "NextCollectionIdIncremented", 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsNextCollectionIdIncrementedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(2)]
        public async Task BuildModel_WhenValidNextCollectionIdIncremented_ShouldBuildModelSuccessfullyAsync(double next_id)
        {
            var enumNextCollectionIdIncremented = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumNextCollectionIdIncremented.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.NextCollectionIdIncremented, new BaseOpt<IncrementableU256>(new IncrementableU256(next_id)));

            var model = await _nftsNextCollectionIdIncrementedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "NextCollectionIdIncremented"),
                enumNextCollectionIdIncremented,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("NextCollectionIdIncremented"));
            Assert.That(model.Next_id, Is.EqualTo(next_id));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsNextCollectionIdIncrementedRepository.SearchAsync(new()
            {
                Next_id = NumberCriteria<double>.Equal(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
