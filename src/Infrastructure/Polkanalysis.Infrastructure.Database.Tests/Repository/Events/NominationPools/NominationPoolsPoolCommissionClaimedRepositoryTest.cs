using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
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
using Polkanalysis.Hub;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.NominationPools
{
    public class NominationPoolsPoolCommissionClaimedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsPoolCommissionClaimedRepository _nominationPoolsPoolCommissionClaimedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsPoolCommissionClaimedRepository = new NominationPoolsPoolCommissionClaimedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NominationPoolsPoolCommissionClaimedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsPoolCommissionClaimed.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "PoolCommissionClaimed", 10, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsPoolCommissionClaimedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0u, 200_000_000_000, 20)]
        public async Task BuildModel_WhenValidPoolCommissionClaimed_ShouldBuildModelSuccessfullyAsync(uint pool_id, double commission, double expected1)
        {
            var enumPoolCommissionClaimed = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumPoolCommissionClaimed.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.PoolCommissionClaimed,
                    new BaseTuple<U32, U128>(
                        new U32(pool_id), new U128(new BigInteger(commission))
                        )

            );

            var model = await _nominationPoolsPoolCommissionClaimedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "PoolCommissionClaimed"),
                enumPoolCommissionClaimed,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("PoolCommissionClaimed"));
            Assert.That(model.Pool_id, Is.EqualTo(pool_id));
Assert.That(model.Commission, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsPoolCommissionClaimedRepository.SearchAsync(new()
            {
                Pool_id = NumberCriteria<uint>.Equal(10),
				Commission = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
