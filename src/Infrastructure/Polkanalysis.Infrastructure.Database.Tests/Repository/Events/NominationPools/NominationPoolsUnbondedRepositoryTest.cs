using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Hub;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
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
    public class NominationPoolsUnbondedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsUnbondedRepository _nominationPoolsUnbondedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsUnbondedRepository = new NominationPoolsUnbondedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NominationPoolsUnbondedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsUnbonded.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "Unbonded", Alice.ToString(), 20, 30, 40, 50));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsUnbondedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, 10u, 300_000_000_000, 400_000_000_000, 40u, 30, 40)]
        public async Task BuildModel_WhenValidUnbonded_ShouldBuildModelSuccessfullyAsync(string member, uint pool_id, double balance, double points, uint era, double expected1, double expected2)
        {
            var bt = new BaseTuple<SubstrateAccount, U32, U128, U128, U32>();
            bt.Create(new SubstrateAccount(member), new U32(pool_id), new U128(new BigInteger(balance)), new U128(new BigInteger(points)), new U32(era));
            var enumUnbonded = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumUnbonded.Create(Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Unbonded, bt);

            var model = await _nominationPoolsUnbondedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "Unbonded"),
                enumUnbonded,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Unbonded"));
            Assert.That(model.Member, Is.EqualTo(member));
            Assert.That(model.Pool_id, Is.EqualTo(pool_id));
            Assert.That(model.Era, Is.EqualTo(era));
            Assert.That(model.Balance, Is.EqualTo(expected1));
            Assert.That(model.Points, Is.EqualTo(expected2));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsUnbondedRepository.SearchAsync(new()
            {
                Member = Alice.ToString(),
                Pool_id = NumberCriteria<uint>.Equal(20),
                Balance = NumberCriteria<double>.Equal(30),
                Points = NumberCriteria<double>.Equal(40),
                Era = NumberCriteria<uint>.Equal(50)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
