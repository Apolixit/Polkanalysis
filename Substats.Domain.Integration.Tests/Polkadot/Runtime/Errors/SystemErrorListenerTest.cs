using Substats.Domain.Contracts;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Runtime;
using Substats.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Substats.Domain.Runtime.Module;

namespace Substats.Domain.Integration.Tests.Polkadot.Runtime.Errors
{
    public class SystemErrorListenerTest : PolkadotIntegrationTest
    {
        private ISubstrateDecoding _substrateDecode;

        public SystemErrorListenerTest()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                _substrateRepository,
                new PalletBuilder(
                    _substrateRepository,
                    new CurrentMetaData(
                        _substrateRepository,
                        Substitute.For<ILogger<CurrentMetaData>>())),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        [TestCase("0x00020000000001030504000000D861040D00000000000000")]
        public void System_ExtrinsicFailed_Index_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
        }

        [Test]
        [TestCase("0x000100000000002861D5DD77000000020000")]
        public void RuntimeEvent_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
        }
    }
}
