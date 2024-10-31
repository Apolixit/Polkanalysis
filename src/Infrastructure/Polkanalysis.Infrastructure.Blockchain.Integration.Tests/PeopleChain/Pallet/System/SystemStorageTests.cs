using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Common.Repository.Pallet.System;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
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

        [Test]
        [TestCase(10000)]
        public async Task GetAllAccounts_ShouldWorkAsync(int nb)
        {
            await SystemStorageAbstractTests.GetAllAccounts_ShouldWorkAsync(_substrateRepository, nb);
        }

        [Test]
        [TestCaseSource(nameof(AllBlockVersionTestCases))]
        public async Task Number_ShouldWorkAsync(int block)
        {
            var blockNum = await _substrateRepository.At(block).Storage.System.NumberAsync(CancellationToken.None);
            Assert.That(blockNum, Is.Not.Null);
            Assert.That(blockNum.Value, Is.GreaterThan(0));
        }

        [Test]
        [TestCaseSource(nameof(AllBlockVersionTestCases))]
        public async Task BlockWeight_ShouldWorkAsync(int block)
        {
            var res = await _substrateRepository.At(block).Storage.System.BlockWeightAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task BlockHash_ShouldWorkAsync()
        {
            var blockId = await _substrateRepository.Storage.System.NumberAsync(CancellationToken.None);
            var res = await _substrateRepository.Storage.System.BlockHashAsync(new U32(blockId - 10), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(nameof(AllBlockVersionTestCases))]
        public async Task ParentHash_ShouldWorkAsync(int block)
        {
            var res = await _substrateRepository.At(block).Storage.System.ParentHashAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(nameof(AllBlockVersionTestCases))]
        public async Task Digest_ShouldWorkAsync(int block)
        {
            var res = await _substrateRepository.At(block).Storage.System.DigestAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(nameof(AllBlockVersionTestCases))]
        public async Task LastRuntimeUpgrade_ShouldWorkAsync(int blockNumber)
        {
            var res = await _substrateRepository.At(blockNumber).Storage.System.LastRuntimeUpgradeAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
