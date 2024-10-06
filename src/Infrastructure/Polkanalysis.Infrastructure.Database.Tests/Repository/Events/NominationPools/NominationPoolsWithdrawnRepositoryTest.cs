using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
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
    public class NominationPoolsWithdrawnRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsWithdrawnRepository _nominationPoolsWithdrawnRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsWithdrawnRepository = new NominationPoolsWithdrawnRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NominationPoolsWithdrawnRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsWithdrawn.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "Withdrawn", Alice.ToString(), 20, 30, 40));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsWithdrawnRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, 10u, 300_000_000_000, 400_000_000_000, 30, 40)]
        public async Task BuildModel_WhenValidWithdrawn_ShouldBuildModelSuccessfullyAsync(string member, uint pool_id, double balance, double points, double expected1, double expected2)
        {
            var enumWithdrawn = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumWithdrawn.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Withdrawn,
                    new BaseTuple<SubstrateAccount, U32, U128, U128>(
                        new SubstrateAccount(member), new U32(pool_id), new U128(new BigInteger(balance)), new U128(new BigInteger(points))
                        )

            );

            var model = await _nominationPoolsWithdrawnRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "Withdrawn"),
                enumWithdrawn,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Withdrawn"));
            Assert.That(model.Member, Is.EqualTo(member));
Assert.That(model.Pool_id, Is.EqualTo(pool_id));
Assert.That(model.Balance, Is.EqualTo(expected1));
				Assert.That(model.Points, Is.EqualTo(expected2));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsWithdrawnRepository.SearchAsync(new()
            {
                Member = Alice.ToString(),
				Pool_id = NumberCriteria<uint>.Equal(20),
				Balance = NumberCriteria<double>.Equal(30),
				Points = NumberCriteria<double>.Equal(40)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
