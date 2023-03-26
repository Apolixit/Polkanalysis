using NUnit.Framework;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Timestamp
{
    public class TimestampStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task Now_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Timestamp.NowAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }


        [Test]
        public async Task DidUpdate_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Timestamp.DidUpdateAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
