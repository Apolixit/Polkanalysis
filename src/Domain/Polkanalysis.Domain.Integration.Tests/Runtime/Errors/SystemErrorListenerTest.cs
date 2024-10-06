using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error;

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

        /// <summary>
        /// https://polkadot.subscan.io/event?block=22666089&page_size=25&page=3
        /// </summary>
        [Test]
        public void DecodeEvent_ExtrinsicFail_ShouldSucceed()
        {
            EventRecord ev = new EventRecord();
            ev.Create("0x0002000000015901506F6C6B616E616C797369732E506F6C6B61646F742E4E65744170694578742C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C6901506F6C6B616E616C797369732E506F6C6B61646F742E4E65744170694578742E47656E6572617465642E4D6F64656C2E76313030333030302E706F6C6B61646F745F72756E74696D652E456E756D52756E74696D654576656E740001030707000000075C075F360155EE000000");

            Assert.That(ev, Is.Not.Null);

            var eventNode = _substrateDecode.DecodeEvent(ev, new Substrate.NetApi.Model.Types.Base.Hash("0xd14d9606068b70847edbe551b38e5e9bbd793d49a93f3c5224b194cc66bb2edf"));

            Assert.That(eventNode, Is.Not.Null);

            var phaseNode = eventNode["Phase"][0];
        }

        [Test]
        public void DecodeExtrinsicFail_ShouldSucceed()
        {
            var input = new Substrate.NetApi.Model.Types.Base.BaseTuple<EnumDispatchError, DispatchInfo>();
            input.Create("0x030707000000075C075F360155EE0000");

            var node = _substrateDecode.Decode(input, new Substrate.NetApi.Model.Types.Base.Hash("0xd14d9606068b70847edbe551b38e5e9bbd793d49a93f3c5224b194cc66bb2edf"));

            Assert.That(node, Is.Not.Null);
        }
    }
}
