using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Service;
using Algolia.Search.Models.Common;
using System.Threading;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Events
{
    internal class EventsListenerTests : PolkadotIntegrationTest
    {
        private ISubstrateDecoding _substrateDecode;
        private IMetadataService _currentMetaData;

        [SetUp]
        public void Setup()
        {
            _currentMetaData = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<ICoreService>(),
                                                      Substitute.For<ILogger<MetadataService>>());

            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(
                    _substrateService,
                    _currentMetaData, Substitute.For<ILogger<PalletBuilder>>()),
                _currentMetaData,
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        [TestCase(14032893, 39)]
        [TestCase(14032650, 52)]
        [TestCase(14032915, 32)]
        [TestCase(14033270, 32)]
        public async Task RealDebuggingEvents_ShouldSucceedAsync(int blockNum, int index)
        {
            var events = await _substrateService.At(blockNum).Storage.System.EventsAsync(CancellationToken.None);

            var ev = events.Value[index];
            var eventNode = _substrateDecode.DecodeEvent(ev);

            Assert.That(eventNode, Is.Not.Null);
            Assert.That(eventNode.Module.ToString(), Is.Not.Null);
            Assert.That(eventNode.Method.ToString(), Is.Not.Null);
        }

        [Test]
        public async Task DecodeEvent_FromPeopleChainBlock1_ShouldSuceed()
        {
            
            var hex = "0x100000000000016501506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C9101506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742E47656E6572617465642E4D6F64656C2E76313030323030362E70656F706C655F706F6C6B61646F745F72756E74696D652E456E756D52756E74696D654576656E742C030B000000000000000000016501506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C9101506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742E47656E6572617465642E4D6F64656C2E76313030323030362E70656F706C655F706F6C6B61646F745F72756E74696D652E456E756D52756E74696D654576656E742C04038F0271D5F536B01F5195F4301AB942A28FC7B35FA55DF77BD58BFCAD12FCDFBAFEA7E7AEB368000000000000016501506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C9101506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742E47656E6572617465642E4D6F64656C2E76313030323030362E70656F706C655F706F6C6B61646F745F72756E74696D652E456E756D52756E74696D654576656E740000C2A0A91D000201000001000000016501506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742C2056657273696F6E3D312E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C9101506F6C6B616E616C797369732E50656F706C65436861696E2E4E65744170694578742E47656E6572617465642E4D6F64656C2E76313030323030362E70656F706C655F706F6C6B61646F745F72756E74696D652E456E756D52756E74696D654576656E74000002D929435517020000";
            var eventsRecord = new BaseVec<Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EventRecord>();
            eventsRecord.Create(hex);
            
            //var event1 = _substrateDecode.DecodeEvent(eventsRecord.Value[0], new Hash("0x925308ed2178c2dea2d5046fca2c17b2a31d63f8f3b665936c09c8a462497641"));
            //var event2 = _substrateDecode.DecodeEvent(eventsRecord.Value[1], new Hash("0x925308ed2178c2dea2d5046fca2c17b2a31d63f8f3b665936c09c8a462497641"));
            var event3 = _substrateDecode.DecodeEvent(eventsRecord.Value[2], new Hash("0x925308ed2178c2dea2d5046fca2c17b2a31d63f8f3b665936c09c8a462497641"));
            //var event4 = _substrateDecode.DecodeEvent(eventsRecord.Value[3], new Hash("0x925308ed2178c2dea2d5046fca2c17b2a31d63f8f3b665936c09c8a462497641"));

            //Assert.That(res[0][0].Name, Is.EqualTo("ApplyExtrinsics"));
            //Assert.That(res[1][0][0].HumanData, Is.EqualTo(0));
        }

        
    }
}
