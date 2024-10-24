using Substrate.NetApi.Model.Extrinsics;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;

namespace Polkanalysis.Domain.Integration.Tests.Service.Explorer
{
    [CancelAfter(RepositoryMaxTimeout)]
    public class ExplorerExtrinsicsTests : ExplorerRepositoryTest
    {
        [Test]
        [TestCase(22708837)]
        [TestCase(20172644)]
        [TestCase(13564726)]
        [TestCase(11062877)]
        public async Task GetExtrinsics_WithValidBlockNumber_ShouldWorkAsync(
            int blockId)
        {
            var extrinsicInfoWithNumber = await _explorerRepository.GetExtrinsicsAsync((uint)blockId, CancellationToken.None);

            Assert.That(extrinsicInfoWithNumber, Is.Not.Null);

            // One of these extrinsics should have Timestamp.Set defined
            Assert.That(
                extrinsicInfoWithNumber.Any(x =>
                x.PalletName == "Timestamp" && x.CallEventName == "set"),
                Is.True);
        }

        /// <summary>
        /// https://polkadot.subscan.io/extrinsic/0x2c4a2d042e4992b74e54666a98f2252152b3dc37ead140c8277cfada09393019
        /// </summary>
        /// <param name="extrinsicHash"></param>
        [Test]
        [TestCase("0x280403000b207eba5c8501", "0xe95401c4b25965e5c528909513e71f7017d9dbfeb02e6b41d70997f2ab872829")]
        public async Task GetExtrinsic_ShouldWorkAsync(string extrinsicHash, string blockHash)
        {
            var extrinsic = new TempOldExtrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = await _substrateDecoding.DecodeExtrinsicAsync(extrinsic, new Substrate.NetApi.Model.Types.Base.Hash(blockHash), CancellationToken.None);
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

        /// <summary>
        /// Based on real data : https://polkadot.subscan.io/block/22666089
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetExtrinsicsAssociateToBlock_CheckEveryDetails_FromBlockNumber_22666089_ShouldWorkAsync()
        {
            var extrinsicInformations = await _explorerRepository.GetExtrinsicsAsync(22666089, CancellationToken.None);

            Assert.That(extrinsicInformations, Is.Not.Null);
            Assert.That(extrinsicInformations.Count(), Is.EqualTo(3));

            var extrinsicsList = extrinsicInformations.ToList();
            Assert.That(extrinsicsList.All(x => x.BlockNumber == 22666089));

            // The first is timestamp set
            var first = extrinsicsList[0];
            Assert.That(first.PalletName, Is.EqualTo("Timestamp"));
            Assert.That(first.CallEventName, Is.EqualTo("set"));

            // The second is parainherent enter
            var second = extrinsicsList[1];
            Assert.That(second.PalletName, Is.EqualTo("ParaInherent"));
            Assert.That(second.CallEventName, Is.EqualTo("enter"));

            var third = extrinsicsList[2];
            Assert.That(third.PalletName, Is.EqualTo("Staking"));
            Assert.That(third.CallEventName, Is.EqualTo("unbond"));
            Assert.That(third.Status.Status, Is.EqualTo(ExtrinsicStatusDto.ExtrinsicStatus.Failed));

        }
    }
}
