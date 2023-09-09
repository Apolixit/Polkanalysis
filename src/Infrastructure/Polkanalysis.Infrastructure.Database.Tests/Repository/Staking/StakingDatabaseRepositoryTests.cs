using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Staking;
using Polkanalysis.Infrastructure.Database.Repository.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Staking
{
    internal class StakingDatabaseRepositoryTests : DatabaseTests
    {
        private ISubstrateService _substrateService;
        private IStakingDatabaseRepository _stakingDatabaseRepository;
        

        public const string MockAddress = "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS";
        public const string MockAddress2 = "13b9d23v1Hke7pcVk8G4gh3TBckDtrwFZUnqPkHezq4praEY";
        public const string MockAddress3 = "12RVY2KvBCyBuKXNEpjqWVFaePhURwubBXqcyXKsEKdhhujG";

        [SetUp]
        public void Setup()
        {
            base.SetupBase();

            _substrateService = Substitute.For<ISubstrateService>();
            _substrateService.BlockchainName.Returns("Polkadot");

            _stakingDatabaseRepository = new StakingDatabaseRepository(
                _substrateDbContext,
                Substitute.For<ILogger<StakingDatabaseRepository>>(),
                _substrateService);
        }

        private void insertFakeData(int eraId, string validatorAddress)
        {
            _stakingDatabaseRepository.InsertEraStakers(
                new U32((uint)eraId),
                new(
                    new BaseTuple<U32, SubstrateAccount>(new U32((uint)eraId), new SubstrateAccount(validatorAddress)),
                    new Exposure(
                        new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32((uint)Faker.RandomNumber.Next(1, 10_000)))),
                        new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32((uint)Faker.RandomNumber.Next(1, 10_000)))),
                        new BaseVec<IndividualExposure>(new IndividualExposure[] {
                            new IndividualExposure(
                                new SubstrateAccount(MockAddress2),
                                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32((uint)Faker.RandomNumber.Next(1, 10_000))))
                            ),
                            new IndividualExposure(
                                new SubstrateAccount(MockAddress3),
                                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32((uint)Faker.RandomNumber.Next(1, 10_000))))
                            )
                        })
                )));
        }

        [Test]
        public void InsertEraStakers_WithValidParameters_ShouldSuceed()
        {
            int lastId = 0;
            if (_substrateDbContext.EraStakersModels.Any())
                lastId = _substrateDbContext.EraStakersModels.Last().EraStakersId;

            var initialCount = _substrateDbContext.EraStakersModels.Count();

            // Test parameters
            uint eraId = 1000;
            string validatorAddress = MockAddress;
            uint totalStaked = 4000;
            uint ownStaker = 1000;

            string nominator1 = MockAddress2;
            uint nominatorStake1 = 400;

            string nominator2 = MockAddress3;
            uint nominatorStake2 = 600;

            _stakingDatabaseRepository.InsertEraStakers(
                new U32(eraId),
                new(
                    new BaseTuple<U32, SubstrateAccount>(new U32(eraId), new SubstrateAccount(MockAddress)),
                    new Exposure(
                        new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32(totalStaked))),
                        new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32(ownStaker))),
                        new BaseVec<IndividualExposure>(new IndividualExposure[] {
                            new IndividualExposure(
                                new SubstrateAccount(nominator1),
                                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32(nominatorStake1)))
                            ),
                            new IndividualExposure(
                                new SubstrateAccount(nominator2),
                                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(new U32(nominatorStake2)))
                            )
                        })
                )));

            // Now we want one more entry, with eraStakerId incremented by one, and all data saved corretly
            Assert.That(_substrateDbContext.EraStakersModels.Count(), Is.EqualTo(initialCount + 1));

            var lastEraStaker = _substrateDbContext.EraStakersModels.Last();
            Assert.That(lastEraStaker.EraStakersId, Is.EqualTo(lastId + 1));

            Assert.That(lastEraStaker.BlockchainName, Is.EqualTo("Polkadot"));
            Assert.That(lastEraStaker.EraId, Is.EqualTo(eraId));
            Assert.That(lastEraStaker.ValidatorAddress, Is.EqualTo(validatorAddress));
            Assert.That(lastEraStaker.TotalStake, Is.EqualTo(new BigInteger(totalStaked)));
            Assert.That(lastEraStaker.OwnStake, Is.EqualTo(new BigInteger(ownStaker)));

            Assert.That(lastEraStaker.EraNominatorsVote.Count, Is.EqualTo(2));
            Assert.That(lastEraStaker.EraNominatorsVote.First(), Is.EqualTo(new EraStakersNominatorsModel()
            {
                EraStakers = lastEraStaker,
                NominatorAddress = nominator1,
                ValueStake = nominatorStake1
            }));

            Assert.That(lastEraStaker.EraNominatorsVote.Last(), Is.EqualTo(new EraStakersNominatorsModel()
            {
                EraStakers = lastEraStaker,
                NominatorAddress = nominator2,
                ValueStake = nominatorStake2
            }));
        }

        [Test]
        public void GetEraStackers_WithValidParameters_ShouldSuceed()
        {
            insertFakeData(200000, MockAddress);

            var res = _stakingDatabaseRepository.GetAllEraStackers(200000);

            Assert.That(res.Count(), Is.EqualTo(1));
            Assert.That(((SubstrateAccount)res.First().Item1.Value[1]).ToPolkadotAddress(), Is.EqualTo(MockAddress));
        }

        [Test]
        [TestCase(100000, MockAddress2, MockAddress3)]
        public async Task GetAllEraStackers_WithValidParameters_ShouldSuceedAsync(int eraId, string validatorAddress1, string validatorAddress2)
        {
            insertFakeData(eraId, validatorAddress1);
            insertFakeData(eraId, validatorAddress2);

            var res1 = await _stakingDatabaseRepository.GetEraValidatorAsync(eraId, new SubstrateAccount(validatorAddress1), CancellationToken.None);
            var res2 = await _stakingDatabaseRepository.GetEraValidatorAsync(eraId, new SubstrateAccount(validatorAddress2), CancellationToken.None);
            var res3 = await _stakingDatabaseRepository.GetEraValidatorAsync(eraId, new SubstrateAccount("1KSsKAbCmnAheLRMr6pQ3kUnLDhMtn3dVwwy3cSYHf5t3hz"), CancellationToken.None);

            Assert.That(res1, Is.Not.Null);
            Assert.That(res2, Is.Not.Null);
            Assert.That(res3, Is.Null);
        }

        [Test]
        [TestCase(100000, MockAddress2)]
        public async Task GetNbNominatorForGivenValidator_ShouldSuceedAsync(int eraId, string validatorAddress1)
        {
            // Fake data insert 2 nominators for this validator
            insertFakeData(eraId, validatorAddress1);

            var res1 = await _stakingDatabaseRepository.GetNominatorCountVotedForValidatorAsync(eraId, new SubstrateAccount(validatorAddress1), CancellationToken.None);
            Assert.That(res1, Is.EqualTo(2));

            // This validator does not exist, so return 0
            var res2 = await _stakingDatabaseRepository.GetNominatorCountVotedForValidatorAsync(eraId, new SubstrateAccount("1KSsKAbCmnAheLRMr6pQ3kUnLDhMtn3dVwwy3cSYHf5t3hz"), CancellationToken.None);

            Assert.That(res2, Is.EqualTo(0));
        }
    }
}
