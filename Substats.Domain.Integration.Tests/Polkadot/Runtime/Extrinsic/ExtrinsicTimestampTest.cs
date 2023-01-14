using Ajuna.NetApi.Model.Extrinsics;
using Substats.Domain.Contracts;
using Substats.Domain.Contracts;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Runtime;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Infrastructure.DirectAccess.Runtime;
using Substats.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Integration.Tests.Polkadot.Runtime.Extrinsic
{
    public class ExtrinsicTimestampTest : PolkadotIntegrationTest
    {

        private ISubstrateDecoding _substrateDecode;
        private ICurrentMetaData _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = new CurrentMetaData(
                _substrateRepository,
                Substitute.For<ILogger<CurrentMetaData>>());

            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                _substrateRepository,
                new PalletBuilder(
                    _substrateRepository,
                    _currentMetaData),
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
            var extrinsic = new Ajuna.NetApi.Model.Extrinsics.Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            var res = _substrateDecode.DecodeExtrinsic(extrinsic);
            Assert.IsTrue(true);
        }
    }
}
