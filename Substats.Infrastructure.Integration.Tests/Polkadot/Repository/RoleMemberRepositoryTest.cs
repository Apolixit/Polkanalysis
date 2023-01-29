﻿using Substats.Domain.Contracts.Secondary;
using Substats.Integration.Tests.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Domain.Runtime;

namespace Substats.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Repository
{
    public class RoleMemberRepositoryTest : PolkadotIntegrationTest
    {
        private IRoleMemberRepository _roleMemberRepository;

        [SetUp]
        public void Setup()
        {
            _roleMemberRepository = new PolkadotRoleMemberRepository(
                _substrateRepository,
                new PolkadotAccountRepository(_substrateRepository),
                new EventNode());
        }

        [Test]
        [TestCase("5C4i2nwtkzX3ANCq1dsgLcbW8bCfKJJHVHBzk776JAbqoRRw")]
        //111B8CxcmnWbuDLyGvgUmRezDCK1brRZmvUuQ6SrFdMyc3S
        public async Task ValidValidator_GetDetails_ShouldWorkAsync(string validatorAddress)
        {
            var res = await _roleMemberRepository.GetValidatorDetailAsync(validatorAddress, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase("168ADXbadY5FkE2txZkzeqhVqmDkivh41Vgn3bZ4yepv8n9x")]
        public async Task ValidNominator_GetDetails_ShouldWorkAsync(string validatorAddress)
        {
            var res = await _roleMemberRepository.GetNominatorDetailAsync(validatorAddress, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(1)]
        public async Task ValidPoolNumber_GetDetails_ShouldWorkAsync(int poolNumber)
        {
            var res = await _roleMemberRepository.GetPoolDetailAsync((uint)poolNumber, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}