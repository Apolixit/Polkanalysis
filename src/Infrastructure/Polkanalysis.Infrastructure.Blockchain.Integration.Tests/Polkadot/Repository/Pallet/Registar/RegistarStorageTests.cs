﻿using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Registar
{
    public class RegistarStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task NextFreeParaId_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Registrar.NextFreeParaIdAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(2094)]
        public async Task Paras_ShouldWorkAsync(int paraId)
        {
            var res = await _substrateService.Storage.Registrar.ParasAsync(new Id((uint)paraId), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
