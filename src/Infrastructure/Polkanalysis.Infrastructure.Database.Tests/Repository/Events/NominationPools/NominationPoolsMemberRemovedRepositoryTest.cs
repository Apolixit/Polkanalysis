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
    public class NominationPoolsMemberRemovedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsMemberRemovedRepository _nominationPoolsMemberRemovedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsMemberRemovedRepository = new NominationPoolsMemberRemovedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NominationPoolsMemberRemovedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsMemberRemoved.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "MemberRemoved", 10, Bob.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsMemberRemovedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0u, MockAddress2)]
        public async Task BuildModel_WhenValidMemberRemoved_ShouldBuildModelSuccessfullyAsync(uint pool_id, string member)
        {
            var enumMemberRemoved = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumMemberRemoved.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.MemberRemoved,
                    new BaseTuple<U32, SubstrateAccount>(
                        new U32(pool_id), new SubstrateAccount(member)
                        )

            );

            var model = await _nominationPoolsMemberRemovedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "MemberRemoved"),
                enumMemberRemoved,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("MemberRemoved"));
            Assert.That(model.Pool_id, Is.EqualTo(pool_id));
Assert.That(model.Member, Is.EqualTo(member));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsMemberRemovedRepository.SearchAsync(new()
            {
                Pool_id = NumberCriteria<uint>.Equal(10),
				Member = Bob.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
