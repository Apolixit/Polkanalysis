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
    public class NominationPoolsPaidOutRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsPaidOutRepository _nominationPoolsPaidOutRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsPaidOutRepository = new NominationPoolsPaidOutRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NominationPoolsPaidOutRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsPaidOut.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "PaidOut", Alice.ToString(), 20, 30));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsPaidOutRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, 10u, 300_000_000_000, 30)]
        public async Task BuildModel_WhenValidPaidOut_ShouldBuildModelSuccessfullyAsync(string member, uint pool_id, double payout, double expected1)
        {
            var enumPaidOut = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumPaidOut.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.PaidOut,
                    new BaseTuple<SubstrateAccount, U32, U128>(
                        new SubstrateAccount(member), new U32(pool_id), new U128(new BigInteger(payout))
                        )

            );

            var model = await _nominationPoolsPaidOutRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "PaidOut"),
                enumPaidOut,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("PaidOut"));
            Assert.That(model.Member, Is.EqualTo(member));
Assert.That(model.Pool_id, Is.EqualTo(pool_id));
Assert.That(model.Payout, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsPaidOutRepository.SearchAsync(new()
            {
                Member = Alice.ToString(),
				Pool_id = NumberCriteria<uint>.Equal(20),
				Payout = NumberCriteria<double>.Equal(30)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
