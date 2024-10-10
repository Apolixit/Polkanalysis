using NUnit.Framework;
using Substrate.NetApi.Model.Rpc;
using System.Threading;

namespace Polkanalysis.Domain.Integration.Tests.Service.Explorer
{
    [CancelAfter(RepositoryMaxTimeout)]
    public class ExplorerBlockTests : ExplorerRepositoryTest
    {
        [Test]
        [TestCase(21604404)]
        [TestCase(14012677)]
        [TestCase(13198574)]
        [TestCase(13210791)]
        [TestCase(13278242)]
        [TestCase(13406835)]
        [TestCase(11062877)]
        public async Task GetBlockDetails_ValidBlockNumber_ShouldWorkAsync(int blockId)
        {
            var blockInfo = await _explorerRepository.GetBlockDetailsAsync((uint)blockId, CancellationToken.None);
            Assert.That(blockInfo, Is.Not.Null);

        }

        [Test]
        [TestCase(21604404, 2)]
        public async Task GetExtrinsicStatus_WithError_ShouldBuildValidDtoAsync(int blockId, int extrinsicId)
        {
            var events = await _substrateService.At(blockId).Storage.System.EventsAsync(CancellationToken.None);
            var extrinsicStatus = await _explorerRepository.GetExtrinsicsStatusAsync(events, extrinsicId, CancellationToken.None);

            Assert.That(extrinsicStatus.Status, Is.EqualTo(Contracts.Dto.Extrinsic.ExtrinsicStatusDto.ExtrinsicStatus.Failed));
        }

        [Test]
        [TestCase(21604404, 2)]
        public async Task GetExtrinsicsLifetimeAsync_ShouldSucceedAsync(int blockId, int extrinsicId)
        {
            var blockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber((uint)blockId), CancellationToken.None);
            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(blockHash, CancellationToken.None);

            var res = await _explorerRepository.GetExtrinsicsLifetimeAsync((uint)blockId, blockDetails.Block.Extrinsics[extrinsicId], CancellationToken.None);

            Assert.That(res.IsImmortal, Is.False);
        }

        [Test]
        [TestCase(21604404, 2)]
        public async Task GetExtrinsicsFeesAsync_ShouldSucceedAsync(int blockId, int extrinsicId)
        {
            var events = await _substrateService.At(blockId).Storage.System.EventsAsync(CancellationToken.None);
            var fees = await _explorerRepository.GetExtrinsicsFeesAsync(events, extrinsicId, CancellationToken.None);

            Assert.That(fees, Is.Not.Null);
            Assert.That(fees, Is.GreaterThan(0));
        }

        [Test]
        [TestCase(15577810, "15AcyKihrmGs9RD4AHUwRvv6LkhbeDyGH3GVADp1Biv4bfFv")]
        public async Task GetBlockAuthor_ValidBlockNumber_ShouldWorkAsync(int blockId, string validatorAddress)
        {
            var validatorAccount = await _explorerRepository.GetBlockAuthorAsync((uint)blockId, CancellationToken.None);

            Assert.That(validatorAccount, Is.Not.Null);
            Assert.That(validatorAccount.ToPolkadotAddress(), Is.EqualTo(validatorAddress));
        }

        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        [TestCase("0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        [TestCase("0xd2dfa1ad34d76b8f0fac8b6db4f4bf9f6be23c3608029276ee2cb11155547967")]
        public async Task GetBlockDetails_ValidBlockHash_ShouldWorkAsync(string blockString)
        {
            var blockInfo = await _explorerRepository.GetBlockDetailsAsync(blockString, CancellationToken.None);
            Assert.That(blockInfo, Is.Not.Null);
        }

        [Test]
        [TestCase(10)]
        public async Task GetLastBlocks_ShouldWorkAsync(int nbBlock)
        {
            var res = await _explorerRepository.GetLastBlocksAsync(nbBlock, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count(), Is.EqualTo(nbBlock));
            Assert.That(res.Select(x => x.Number).Distinct().Count, Is.EqualTo(nbBlock));
        }
    }
}
