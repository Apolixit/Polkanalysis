using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Integration.Tests.Polkadot;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Extrinsic
{
    public class ExtrinsicBalancesTests : PolkadotIntegrationTest
    {
        private ISubstrateDecoding _substrateDecode;
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = new CurrentMetaData(
                _substrateService,
                Substitute.For<ILogger<CurrentMetaData>>());

            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(
                    _substrateService,
                    _currentMetaData),
                _currentMetaData,
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/extrinsics/decode/0x4d02840007c12e8b63d2592412cbbde38e96181551234bb57ec8438c1281e212b5bed72b00318754fcfffb692021adf1488e2fc8df0190c1db3ad9090d39ca49b380e562c50f322e97cb0a6606c6fd5e00cdd5d14bf5f9dfe2abdc596cd8b93cde2b8fa7028607b26a040000050300d2272d2d960c438ad1fa6e93a37e510068d9965802a469e941514f3c1bdcb54b0732b905f62f
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x4d02840007c12e8b63d2592412cbbde38e96181551234bb57ec8438c1281e212b5bed72b00318754fcfffb692021adf1488e2fc8df0190c1db3ad9090d39ca49b380e562c50f322e97cb0a6606c6fd5e00cdd5d14bf5f9dfe2abdc596cd8b93cde2b8fa7028607b26a040000050300d2272d2d960c438ad1fa6e93a37e510068d9965802a469e941514f3c1bdcb54b0732b905f62f")]
        public void BalancesExtrinsic_TransferKeepAlice_ShouldWork(string extrinsicHash)
        {
            var extrinsic = new Substrate.NetApi.Model.Extrinsics.Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = _substrateDecode.DecodeExtrinsic(extrinsic);
            Assert.That(res.Name, Is.EqualTo("Balances"));
            Assert.That(res.Has("transfer_keep_alive"), Is.True);
        }
    }
}
