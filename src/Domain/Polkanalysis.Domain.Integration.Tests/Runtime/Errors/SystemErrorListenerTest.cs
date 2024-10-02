using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Errors
{
    public class SystemErrorListenerTest : PolkadotIntegrationTest
    {
        private readonly ISubstrateDecoding _substrateDecode;

        public SystemErrorListenerTest()
        {
            var currentMetadata = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<ICoreService>(),
                                                      Substitute.For<ILogger<MetadataService>>());

            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(_substrateService, currentMetadata, Substitute.For<ILogger<PalletBuilder>>()),
                currentMetadata,
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test, Ignore("Todo : find a new test case ?")]
        [TestCase("0x00020000000001030504000000D861040D00000000000000")]
        public void System_ExtrinsicFailed_Index_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);

            Assert.That(result.EventName, Is.EqualTo("ExtrinsicFailed"));
        }

        [Test]
        [TestCase("0x000100000000002861D5DD77000000020000")]
        public void RuntimeEvent_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);

            var result = EventResult.Create(nodeResult.Children[1].Children[0]);

            Assert.That(result.EventName, Is.EqualTo("ExtrinsicSuccess"));
        }
    }
}
