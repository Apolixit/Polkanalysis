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
                                                      Substitute.For<IExplorerService>(),
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
        [TestCase(14032650, 52)]
        [TestCase(14032893, 39)]
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
    }
}
