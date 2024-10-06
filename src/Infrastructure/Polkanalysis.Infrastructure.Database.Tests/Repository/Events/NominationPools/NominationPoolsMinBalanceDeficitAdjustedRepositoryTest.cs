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
    public class NominationPoolsMinBalanceDeficitAdjustedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsMinBalanceDeficitAdjustedRepository _nominationPoolsMinBalanceDeficitAdjustedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsMinBalanceDeficitAdjustedRepository = new NominationPoolsMinBalanceDeficitAdjustedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NominationPoolsMinBalanceDeficitAdjustedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsMinBalanceDeficitAdjusted.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "MinBalanceDeficitAdjusted", 10, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsMinBalanceDeficitAdjustedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0u, 200_000_000_000, 20)]
        public async Task BuildModel_WhenValidMinBalanceDeficitAdjusted_ShouldBuildModelSuccessfullyAsync(uint pool_id, double amount, double expected1)
        {
            var enumMinBalanceDeficitAdjusted = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumMinBalanceDeficitAdjusted.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.MinBalanceDeficitAdjusted,
                    new BaseTuple<U32, U128>(
                        new U32(pool_id), new U128(new BigInteger(amount))
                        )

            );

            var model = await _nominationPoolsMinBalanceDeficitAdjustedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "MinBalanceDeficitAdjusted"),
                enumMinBalanceDeficitAdjusted,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("MinBalanceDeficitAdjusted"));
            Assert.That(model.Pool_id, Is.EqualTo(pool_id));
Assert.That(model.Amount, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsMinBalanceDeficitAdjustedRepository.SearchAsync(new()
            {
                Pool_id = NumberCriteria<uint>.Equal(10),
				Amount = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
