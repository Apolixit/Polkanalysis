using Substrate.NetApi.Model.Extrinsics;
using NUnit.Framework;

namespace Polkanalysis.Domain.Integration.Tests.Service.Explorer
{
    [CancelAfter(RepositoryMaxTimeout)]
    public class ExplorerExtrinsicsTests : ExplorerRepositoryTest
    {
        [Test]
        [TestCase(20172644, "0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        [TestCase(13564726, "0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        [TestCase(11062877, "0xe64c10be69da2b309d88c1d5f18a1d5e9b6766a6e3003fb1f5932d1701f59fd0")]
        public async Task GetExtrinsicsAssociateToBlock_WithValidBlockNumber_ShouldWorkAsync(
            int blockId,
            string _blockHash)
        {
            var extrinsicInfoWithNumber = await _explorerRepository.GetExtrinsicsAsync((uint)blockId, CancellationToken.None);

            Assert.That(extrinsicInfoWithNumber, Is.Not.Null);

            // One of these extrinsics should have Timestamp.Set defined
            //Assert.That(
            //    extrinsicInfoWithNumber.Any(x =>
            //    x.Decoded.Has("Timestamp")),
            //    Is.True);
        }

        /// <summary>
        /// https://polkadot.subscan.io/extrinsic/0x2c4a2d042e4992b74e54666a98f2252152b3dc37ead140c8277cfada09393019
        /// </summary>
        /// <param name="extrinsicHash"></param>
        [Test]
        [TestCase("0x280403000b207eba5c8501")]
        public void GetExtrinsic_ShouldWork(string extrinsicHash)
        {
            var extrinsic = new Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = _substrateDecoding.DecodeExtrinsic(extrinsic);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Based on real data : https://polkadot.subscan.io/block/20626766
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetExtrinsicsAssociateToBlock_CheckEveryDetails_FromBlockNumber_ShouldWorkAsync()
        {
            var extrinsicInformations = await _explorerRepository.GetExtrinsicsAsync(20626766, CancellationToken.None);

            Assert.That(extrinsicInformations, Is.Not.Null);
            Assert.That(extrinsicInformations.Count(), Is.EqualTo(4));

            var extrinsicsList = extrinsicInformations.ToList();
            Assert.That(extrinsicsList.All(x => x.BlockNumber == 20626766));

            // The first is timestamp set
            var first = extrinsicsList[0];
            Assert.That(first.PalletName, Is.EqualTo("Timestamp"));
            Assert.That(first.CallEventName, Is.EqualTo("set"));

            // The second is parainherent enter
            var second = extrinsicsList[1];
            Assert.That(second.PalletName, Is.EqualTo("ParaInherent"));
            Assert.That(second.CallEventName, Is.EqualTo("enter"));

            // The third is proxy announce
            var third = extrinsicsList[2];
            Assert.That(third.PalletName, Is.EqualTo("Proxy"));
            Assert.That(third.CallEventName, Is.EqualTo("announce"));

            // The fourth is nomination pools bond extra
            var fourth = extrinsicsList[3];
            Assert.That(fourth.PalletName, Is.EqualTo("NominationPools"));
            Assert.That(fourth.CallEventName, Is.EqualTo("bond_extra"));
        }
    }
}
