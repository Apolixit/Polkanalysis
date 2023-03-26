using NUnit.Framework;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Registar
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
        public async Task Paras_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Registrar.ParasAsync(new Domain.Contracts.Core.Id(2098) ,CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
