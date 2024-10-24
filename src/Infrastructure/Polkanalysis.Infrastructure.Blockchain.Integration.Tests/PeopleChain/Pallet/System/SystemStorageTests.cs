using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.PeopleChain.Pallet.System
{
    internal class SystemStorageTests : PeopleChainIntegrationTests
    {
        [Test]
        [TestCase(1)]
        public async Task EventsAt_ShouldWorkAsync(int blockNumber)
        {
            var res = await _substrateRepository.At(blockNumber).Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Events_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
