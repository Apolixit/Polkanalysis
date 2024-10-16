using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Extrinsic
{
    public class ExtrinsicBalancesTests : PolkadotIntegrationTest
    {
        private ISubstrateDecoding _substrateDecode;
        private IMetadataService _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = new MetadataService(
                _substrateService,
                _substrateDbContext,
                Substitute.For<ICoreService>(),
                Substitute.For<ILogger<MetadataService>>());

            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(
                    _substrateService,
                    Substitute.For<ILogger<PalletBuilder>>()),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// https://polkadot.subscan.io/extrinsic/22708837-2
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x4502840040D6848BC717060715186ACB55DB1A18566B893A9B4EA43F6AA9ACB3CE42C017013E703B67FF979DF18962DB431D33411368B7C3D377CED6E69E8D267127E0837588698DCB1AEE6D27DBD718EB1B62E6D0B8AA9C0529D7170CC3EACAA7B260888515027C000005030098FA3760E5E58F4A9F47DF8DE89E0639B253F159A9AB9376651D92CA7D1EAB590700046BF414", "0x2395e78d44a83c11eaf3a7019554091229d542c4f709e5233f7a54b4c8635004")]
        public async Task BalancesExtrinsic_TransferKeepAlive_ShouldWorkAsync(string extrinsicHash, string blockHash)
        {
            var extrinsic = new TempOldExtrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = await _substrateDecode.DecodeExtrinsicAsync(extrinsic, new Substrate.NetApi.Model.Types.Base.Hash(blockHash), CancellationToken.None);
            Assert.That(res.Name, Is.EqualTo("Balances"));
            Assert.That(res.Has("transfer_keep_alive"), Is.True);
        }
    }
}
