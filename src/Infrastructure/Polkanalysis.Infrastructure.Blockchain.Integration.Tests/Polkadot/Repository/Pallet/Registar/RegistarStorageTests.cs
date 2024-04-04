using NUnit.Framework;
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
            var res = await _substrateRepository.Storage.Registrar.NextFreeParaIdAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(2094)]
        public async Task Paras_ShouldWorkAsync(int paraId)
        {
            var res = await _substrateRepository.Storage.Registrar.ParasAsync(new Domain.Contracts.Core.Id((uint)paraId), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
