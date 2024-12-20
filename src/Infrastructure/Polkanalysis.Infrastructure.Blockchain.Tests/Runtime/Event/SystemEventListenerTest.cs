﻿using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using SystemEvent = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

namespace Polkanalysis.Domain.Tests.Runtime.Event
{
    public class SystemEventListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;
        
        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        [Test, Ignore("Debug Event updates")]
        [TestCase("0x00010000000000384A7AFE72000000020000")]
        public async Task System_ExtrinsicSuccess_1_ShouldBeParsedAsync(string hex)
        {
            var nodeResult = await _substrateDecode.DecodeEventAsync(hex, CancellationToken.None);
            PrerequisiteEvent(nodeResult);

            //IEventNode eventNode = (IEventNode)nodeResult.Children[1];

            Assert.That(nodeResult.Module, Is.EqualTo(RuntimeEvent.System));
            Assert.That(nodeResult.Method, Is.EqualTo(SystemEvent.Event.ExtrinsicSuccess));
            //var result = EventResult.Create(nodeResult);
            //            {
            //            phase:
            //                {
            //                ApplyExtrinsic: 1
            //            }
            //    event: {
            //        method: ExtrinsicSuccess
            //        section: system
            //        index: 0x0000
            //      data:
            //            {
            //            dispatchInfo:
            //                {
            //                weight: 493,895,699,000
            //          class: Mandatory
            //          paysFee: Yes
            //    }
            //}
            //    }
            //    topics: []
            //  }
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L495
        /// Pallet system
        /// extrinsic success
        /// Pays fees 0
        /// Class 2
        ///  Weight 158080000
        /// </summary>
        /// <param name="hex"></param>
        [Test, Ignore("Debug Event updates")]
        [TestCase("0x00000000000000001C6C0900000000020000")]
        public async Task System_ExtrinsicSuccess_ShouldBeParsedAsync(string hex)
        {
            var nodeResult = await _substrateDecode.DecodeEventAsync(hex, CancellationToken.None);
            PrerequisiteEvent(nodeResult);

            //IEventNode eventNode = (IEventNode)nodeResult.Children[1];

            Assert.That(nodeResult.Module, Is.EqualTo(RuntimeEvent.System));
            Assert.That(nodeResult.Method, Is.EqualTo(SystemEvent.Event.ExtrinsicSuccess));
        }
    }
}
