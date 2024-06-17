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
    public class NominationPoolsCreatedRepositoryTest : EventsDatabaseTests
    {
        private NominationPoolsCreatedRepository _nominationPoolsCreatedRepository;

        [SetUp]
        public void Setup()
        {
            _nominationPoolsCreatedRepository = new NominationPoolsCreatedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NominationPoolsCreatedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNominationPoolsCreated.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "NominationPools", "Created", Alice.ToString(), 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nominationPoolsCreatedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, 10u)]
        public async Task BuildModel_WhenValidCreated_ShouldBuildModelSuccessfullyAsync(string depositor, uint pool_id)
        {
            var enumCreated = new Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent();
            enumCreated.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Created,
                    new BaseTuple<SubstrateAccount, U32>(
                        new SubstrateAccount(depositor), new U32(pool_id)
                        )

            );

            var model = await _nominationPoolsCreatedRepository.BuildModelAsync(
                BuildEventModel("NominationPools", "Created"),
                enumCreated,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("NominationPools"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Created"));
            Assert.That(model.Depositor, Is.EqualTo(depositor));
Assert.That(model.Pool_id, Is.EqualTo(pool_id));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nominationPoolsCreatedRepository.SearchAsync(new()
            {
                Depositor = Alice.ToString(),
				Pool_id = NumberCriteria<uint>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
