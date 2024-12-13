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
    public class NftsDestroyedRepositoryTest : EventsDatabaseTests
    {
        private NftsDestroyedRepository _nftsDestroyedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsDestroyedRepository = new NftsDestroyedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsDestroyedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsDestroyed.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "Destroyed", 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsDestroyedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0)]
        public async Task BuildModel_WhenValidDestroyed_ShouldBuildModelSuccessfullyAsync(double collection)
        {
            var enumDestroyed = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumDestroyed.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.Destroyed,
                        new IncrementableU256(collection)
            );

            var model = await _nftsDestroyedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "Destroyed"),
                enumDestroyed,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Destroyed"));
            Assert.That(model.Collection, Is.EqualTo(collection));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsDestroyedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
