﻿using Substrate.NetApi.Model.Extrinsics;
using NUnit.Framework;

namespace Polkanalysis.Domain.Integration.Tests.Repository.Explorer
{
    [Timeout(RepositoryMaxTimeout)]
    public class ExplorerExtrinsicsTests : ExplorerRepositoryTest
    {
        [Test]
        [TestCase(13564726, "0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        [TestCase(11062877, "0xe64c10be69da2b309d88c1d5f18a1d5e9b6766a6e3003fb1f5932d1701f59fd0")]
        public async Task GetExtrinsicsAssociateToBlock_WithValidBlockNumber_ShouldWorkAsync(
            int blockId,
            string blockHash)
        {
            var extrinsicInfoWithNumber = await _explorerRepository.GetExtrinsicsAsync((uint)blockId, CancellationToken.None);
            var extrinsicInfoWithHash = await _explorerRepository.GetExtrinsicsAsync(blockHash, CancellationToken.None);

            Assert.IsNotNull(extrinsicInfoWithNumber);
            Assert.IsNotNull(extrinsicInfoWithHash);
            var x1 = extrinsicInfoWithNumber.First().Decoded.Has("Timestamp");
            //var x2 = extrinsicInfoWithNumber.First().Decoded.Has("set");

            // One of these extrinsics should have Timestamp.Set defined
            Assert.That(
                extrinsicInfoWithNumber.Any(x =>
                x.Decoded.Has("Timestamp")),
                Is.True);
        }

        /// <summary>
        /// https://polkadot.subscan.io/extrinsic/0x2c4a2d042e4992b74e54666a98f2252152b3dc37ead140c8277cfada09393019
        /// </summary>
        /// <param name="extrinsicHash"></param>
        [Test]
        [TestCase("0x280403000b207eba5c8501")]
        //[TestCase("0x2c4a2d042e4992b74e54666a98f2252152b3dc37ead140c8277cfada09393019")]
        public void GetExtrinsic_ShouldWork(string extrinsicHash)
        {
            var extrinsic = new Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = _substrateDecoding.DecodeExtrinsic(extrinsic);
            Assert.That(res, Is.Not.Null);
        }


    }
}
