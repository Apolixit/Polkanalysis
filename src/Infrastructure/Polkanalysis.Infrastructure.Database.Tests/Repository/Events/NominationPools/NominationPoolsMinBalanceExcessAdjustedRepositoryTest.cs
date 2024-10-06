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

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.NominationPools
{
    public class NominationPoolsMinBalanceExcessAdjustedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsMinBalanceExcessAdjustedRepository _nominationPoolsMinBalanceExcessAdjustedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsMinBalanceExcessAdjustedRepository = new NominationPoolsMinBalanceExcessAdjustedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NominationPoolsMinBalanceExcessAdjustedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsMinBalanceExcessAdjusted.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "MinBalanceExcessAdjusted", 10, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsMinBalanceExcessAdjustedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0u, 200_000_000_000, 20)]
        public async Task BuildModel_WhenValidMinBalanceExcessAdjusted_ShouldBuildModelSuccessfullyAsync(uint pool_id, double amount, double expected1)
        {
            var enumMinBalanceExcessAdjusted = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumMinBalanceExcessAdjusted.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.MinBalanceExcessAdjusted,
                    new BaseTuple<U32, U128>(
                        new U32(pool_id), new U128(new BigInteger(amount))
                        )

            );

            var model = await _nominationPoolsMinBalanceExcessAdjustedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "MinBalanceExcessAdjusted"),
                enumMinBalanceExcessAdjusted,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("MinBalanceExcessAdjusted"));
            Assert.That(model.Pool_id, Is.EqualTo(pool_id));
Assert.That(model.Amount, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsMinBalanceExcessAdjustedRepository.SearchAsync(new()
            {
                Pool_id = NumberCriteria<uint>.Equal(10),
				Amount = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
