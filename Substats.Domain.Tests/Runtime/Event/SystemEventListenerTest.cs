
using Substats.Domain.Contracts;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Runtime;
using Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Substats.Domain.Contracts.Runtime.Module;

namespace Substats.Domain.Tests.Runtime.Event
{
    public class SystemEventListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;
        
        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateRepository>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000000000384A7AFE72000000020000")]
        public void System_ExtrinsicSuccess_1_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.System));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicSuccess));
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
        [TestCase("0x00000000000000001C6C0900000000020000")]
        public void System_ExtrinsicSuccess_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.System));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicSuccess));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L501
        /// 1/3
        /// Transfer balance (1000), Charlie to Ferdie (Ferdie new account)
        /// Pallet system
        /// New account
        /// Address
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000000031CBD2D43530A44705AD088AF313E18F80B53EF16B36177CD4B77B846F2A5F07C00")]
        public void System_NewAccount_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);
            //Ferdie SS58 Address: 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.System));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.frame_system.pallet.Event.NewAccount));
        }
    }
}
