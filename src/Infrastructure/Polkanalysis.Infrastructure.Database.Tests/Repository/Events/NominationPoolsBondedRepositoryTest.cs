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
    public class NominationPoolsBondedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsBondedRepository _nominationPoolsBondedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsBondedRepository = new NominationPoolsBondedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NominationPoolsBondedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsBonded.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "Bonded", Alice.ToString(), 20, 30, false));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsBondedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, 10u, 300_000_000_000, false, 30)]
        public async Task BuildModel_WhenValidBonded_ShouldBuildModelSuccessfullyAsync(string member, uint pool_id, double bonded, bool joined, double expected1)
        {
            var enumBonded = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumBonded.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Bonded,
                    new BaseTuple<SubstrateAccount, U32, U128, Bool>(
                        new SubstrateAccount(member), new U32(pool_id), new U128(new BigInteger(bonded)), new Bool(joined)
                        )

            );

            var model = await _nominationPoolsBondedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "Bonded"),
                enumBonded,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Bonded"));
            Assert.That(model.Member, Is.EqualTo(member));
Assert.That(model.Pool_id, Is.EqualTo(pool_id));
Assert.That(model.Joined, Is.EqualTo(joined));
Assert.That(model.Bonded, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsBondedRepository.SearchAsync(new()
            {
                Member = Alice.ToString(),
				Pool_id = NumberCriteria<uint>.Equal(20),
				Bonded = NumberCriteria<double>.Equal(30),
				Joined = false
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
