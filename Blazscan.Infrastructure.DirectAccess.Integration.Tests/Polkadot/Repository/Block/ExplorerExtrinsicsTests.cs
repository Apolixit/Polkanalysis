using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Integration.Tests.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Block
{
    public class ExplorerExtrinsicsTests : ExplorerRepositoryTest
    {
        [Test]
        [TestCase(13564726, "0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        public async Task GetExtrinsicsAssociateToBlock_WithValidBlockNumber_ShouldWorkAsync(
            int blockId,
            string blockHash)
        {
            var extrinsicInfoWithNumber = await _blockRepository.GetExtrinsicsAsync((uint)blockId, CancellationToken.None);
            var extrinsicInfoWithHash = await _blockRepository.GetExtrinsicsAsync(blockHash, CancellationToken.None);

            Assert.IsNotNull(extrinsicInfoWithNumber);
            Assert.IsNotNull(extrinsicInfoWithHash);

        }

        /// <summary>
        /// https://polkadot.subscan.io/extrinsic/0x2c4a2d042e4992b74e54666a98f2252152b3dc37ead140c8277cfada09393019
        /// </summary>
        /// <param name="extrinsicHash"></param>
        [Test]
        [TestCase("0x280403000b207eba5c8501")]
        [TestCase("0x2c4a2d042e4992b74e54666a98f2252152b3dc37ead140c8277cfada09393019")]
        public void GetExtrinsic_ShouldWork(string extrinsicHash)
        {
            var extrinsic = new Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = _substrateDecoding.DecodeExtrinsic(extrinsic);
            Assert.That(res, Is.Not.Null);
        }
    }
}
