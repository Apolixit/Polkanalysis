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

        [Test]
        [TestCase(710328, "13Jpq4n3PXXaSAbJTMmFD78mXAzs8PzgUUQd5ve8saw7HQS5")]
        public async Task Account_ShouldWorkAsync(int numBlock, string accountAddress)
        {
            var res = await _substrateRepository.At(numBlock).Storage.System.AccountAsync(new Contracts.Core.SubstrateAccount(accountAddress), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
