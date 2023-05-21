﻿using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Integration.Tests.Repository
{
    public class StakingRepositoryTest : PolkadotIntegrationTest
    {
        private IStakingRepository _stakingRepository;

        [SetUp]
        public void Setup()
        {
            _stakingRepository = new StakingRepository(_substrateRepository, new AccountRepository(_substrateRepository));
        }

        [Test]
        public async Task GetValidators_ShouldWorkAsync()
        {
            var validators = await _stakingRepository.GetValidatorsAsync(CancellationToken.None);

            Assert.That(validators, Is.Not.Null);
            Assert.That(validators.Count(), Is.GreaterThan(2));
        }
        [Test]
        public async Task GetValidatorDetail_ShouldWorkAsync()
        {
            var validators = await _substrateRepository.Storage.Session.ValidatorsAsync(CancellationToken.None);

            Assert.That(validators, Is.Not.Null);
            Assert.That(validators.Value.Length, Is.GreaterThanOrEqualTo(1));

            var validatorDetail = await _stakingRepository.GetValidatorDetailAsync(validators.Value.First().ToStringAddress() , CancellationToken.None);
            Assert.That(validatorDetail, Is.Not.Null);
        }

        [Test]
        [TestCase("5C4i2nwtkzX3ANCq1dsgLcbW8bCfKJJHVHBzk776JAbqoRRw")]
        //111B8CxcmnWbuDLyGvgUmRezDCK1brRZmvUuQ6SrFdMyc3S
        public async Task ValidValidator_GetDetails_ShouldWorkAsync(string validatorAddress)
        {
            var res = await _stakingRepository.GetValidatorDetailAsync(validatorAddress, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task GetNominators_ShouldSucceedAsync()
        {
            var validators = await _stakingRepository.GetNominatorsAsync(CancellationToken.None);

            Assert.That(validators, Is.Not.Null);
            Assert.That(validators.Count(), Is.GreaterThan(2));
        }


        [Test]
        [TestCase("168ADXbadY5FkE2txZkzeqhVqmDkivh41Vgn3bZ4yepv8n9x")]
        public async Task ValidNominator_GetDetails_ShouldWorkAsync(string validatorAddress)
        {
            var res = await _stakingRepository.GetNominatorDetailAsync(validatorAddress, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task GetPools_ShouldWorkAsync()
        {
            var res = await _stakingRepository.GetPoolsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(1)]
        public async Task ValidPoolNumber_GetDetails_ShouldWorkAsync(int poolNumber)
        {
            var res = await _stakingRepository.GetPoolDetailAsync((uint)poolNumber, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
