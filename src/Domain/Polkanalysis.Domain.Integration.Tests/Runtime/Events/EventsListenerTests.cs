using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
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
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

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
                    Substitute.For<ILogger<PalletBuilder>>()),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        [TestCase(14000002, 39, "0xdc626d8eb0cd0f16ec1ec6ee5a807113555558bf1996f52566c1d0558ae8b9c4")]
        [TestCase(14032893, 39, "0xdc626d8eb0cd0f16ec1ec6ee5a807113555558bf1996f52566c1d0558ae8b9c4")]
        [TestCase(14032650, 52, "0xf64314561e243e5678acf7e737863897fd7fcb508ed67ef7ae55cca040db70af")]
        [TestCase(14032915, 32, "0x22e313e97be0cf2a93d94b17257771d6558c864d61b8d0630a0b993ee39e56d1")]
        [TestCase(14033270, 32, "0x0f26536564432c3ab92a7922ba25a86823bd71956839dc07752a4821a799b015")]
        public async Task RealDebuggingEvents_ShouldSucceedAsync(int blockNum, int index, string hash)
        {
            var events = await _substrateService.At(blockNum).Storage.System.EventsAsync(CancellationToken.None);

            var ev = events.Value[index];
            var eventNode = await _substrateDecode.DecodeEventAsync(ev, CancellationToken.None, new Hash(hash));

            Assert.That(eventNode, Is.Not.Null);
            Assert.That(eventNode.Module.ToString(), Is.Not.Null);
            Assert.That(eventNode.Method.ToString(), Is.Not.Null);
        }
    }
}
