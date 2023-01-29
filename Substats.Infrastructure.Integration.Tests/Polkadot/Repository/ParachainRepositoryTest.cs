﻿using NUnit.Framework;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Integration.Tests.Polkadot.Repository
{
    public class ParachainRepositoryTest : PolkadotIntegrationTest
    {
        private IParachainRepository _parachainRepository;

        [SetUp]
        public void Setup()
        {
            _parachainRepository = new PolkadotParachainRepository(_substrateRepository);
        }

        [Test]
        [TestCase(2051)]
        public async Task ValidParachain_GetDetails_ShouldWorkAsync(int parachainId)
        {
            var res = await _parachainRepository.GetParachainDetailAsync((uint)parachainId, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}