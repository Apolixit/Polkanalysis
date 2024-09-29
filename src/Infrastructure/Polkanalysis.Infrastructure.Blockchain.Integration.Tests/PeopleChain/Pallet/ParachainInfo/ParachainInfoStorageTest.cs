using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.PeopleChain.Pallet.ParachainInfo
{
    internal class ParachainInfoStorageTest : PeopleChainIntegrationTests
    {
        [Test]
        public async Task ParachainId_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.ParachainInfo.ParachainIdAsync(CancellationToken.None);
            
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value.Value, Is.EqualTo(1004));
        }
    }
}
