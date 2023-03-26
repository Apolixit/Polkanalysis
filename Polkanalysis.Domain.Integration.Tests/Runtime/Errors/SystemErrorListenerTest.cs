using Polkanalysis.Domain.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Errors
{
    public class SystemErrorListenerTest : PolkadotIntegrationTest
    {
        private ISubstrateDecoding _substrateDecode;

        public SystemErrorListenerTest()
        {
            var currentMetadata = new CurrentMetaData(_substrateRepository, Substitute.For<ILogger<CurrentMetaData>>());

            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                _substrateRepository,
                new PalletBuilder(_substrateRepository, currentMetadata),
                currentMetadata,
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
