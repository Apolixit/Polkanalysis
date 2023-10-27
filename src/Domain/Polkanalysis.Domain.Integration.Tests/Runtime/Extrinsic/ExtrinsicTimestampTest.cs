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
    public class ExtrinsicTimestampTest : PolkadotIntegrationTest
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
        /// Extrinsic from here : https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/extrinsics/decode/0x280403000b207eba5c8501
        /// </summary>
        /// <param name="extrinsicHash"></param>
        /// <returns></returns>
        [Test]
        [TestCase("0x280403000b207eba5c8501")]
        public void TimestampsExtrinsic_WithTimeSet_ShouldBeParsed(string extrinsicHash)
        {
            var extrinsic = new Substrate.NetApi.Model.Extrinsics.Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = _substrateDecode.DecodeExtrinsic(extrinsic);
            Assert.IsTrue(true);
        }
    }
}
