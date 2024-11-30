using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Mythos.Pallet.System
{
    public class SystemStorageTests : MythosIntegrationTests
    {
        [Test]
        [TestCase(2680620)]
        public async Task EventsAt_ShouldWorkAsync(int blockNumber)
        {
            var res = await _substrateService.At(blockNumber).Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(2680620, 38)]
        public async Task EventsCount_ShouldWorkAsync(int blockNumber, int expectedEventCount)
        {
            var eventCount = await _substrateService.At(blockNumber).Storage.System.EventCountAsync(CancellationToken.None);
            Assert.That(eventCount.Value, Is.EqualTo(expectedEventCount));
        }
    }
}
