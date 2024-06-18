using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.NominationPools;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.NominationPools
{
    public class NominationPoolsDestroyedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsDestroyedRepository _nominationPoolsDestroyedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsDestroyedRepository = new NominationPoolsDestroyedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NominationPoolsDestroyedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsDestroyed.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "Destroyed", 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsDestroyedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0u)]
        public async Task BuildModel_WhenValidDestroyed_ShouldBuildModelSuccessfullyAsync(uint pool_id)
        {
            var enumDestroyed = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumDestroyed.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Destroyed,
                    new U32(
                        new U32(pool_id)
                        )

            );

            var model = await _nominationPoolsDestroyedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "Destroyed"),
                enumDestroyed,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Destroyed"));
            Assert.That(model.Pool_id, Is.EqualTo(pool_id));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsDestroyedRepository.SearchAsync(new()
            {
                Pool_id = NumberCriteria<uint>.Equal(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
