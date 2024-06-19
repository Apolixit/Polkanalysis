using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Staking
{
    public class StakingEraPaidRepositoryTest : EventsDatabaseTests
    {
        private StakingEraPaidRepository _stakingEraPaidRepository;

        [SetUp]
        public void Setup()
        {
            _stakingEraPaidRepository = new StakingEraPaidRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<StakingEraPaidRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventStakingEraPaid.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Staking", "EraPaid", 10, 20, 30));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_stakingEraPaidRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0u, 200_000_000_000, 300_000_000_000, 20, 30)]
        public async Task BuildModel_WhenValidEraPaid_ShouldBuildModelSuccessfullyAsync(uint era_index, double validator_payout, double remainder, double expected1, double expected2)
        {
            var enumEraPaid = new Blockchain.Contracts.Pallet.Staking.Enums.EnumEvent();
            enumEraPaid.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.Event.EraPaid,
                    new BaseTuple<U32, U128, U128>(
                        new U32(era_index), new U128(new BigInteger(validator_payout)), new U128(new BigInteger(remainder))
                        )

            );

            var model = await _stakingEraPaidRepository.BuildModelAsync(
                BuildEventModel("Staking", "EraPaid"),
                enumEraPaid,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Staking"));
            Assert.That(model.ModuleEvent, Is.EqualTo("EraPaid"));
            Assert.That(model.Era_index, Is.EqualTo(era_index));
Assert.That(model.Validator_payout, Is.EqualTo(expected1));
				Assert.That(model.Remainder, Is.EqualTo(expected2));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _stakingEraPaidRepository.SearchAsync(new()
            {
                Era_index = NumberCriteria<uint>.Equal(10),
				Validator_payout = NumberCriteria<double>.Equal(20),
				Remainder = NumberCriteria<double>.Equal(30)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
