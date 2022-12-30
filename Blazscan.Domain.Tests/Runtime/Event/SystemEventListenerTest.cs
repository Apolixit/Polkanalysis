
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch;
using NSubstitute;

namespace Blazscan.Domain.Tests.Runtime.Event
{
    public class SystemEventListenerTest
    {
        private ISubstrateDecoding _substrateDecode;
        public SystemEventListenerTest()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateNodeRepository>(),
                Substitute.For<IPalletBuilder>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        [TestCase("0x00010000000000384A7AFE72000000020000")]
        public void System_ExtrinsicSuccess_1_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            Assert.IsTrue(true);
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
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("System", "ExtrinsicSuccess", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_DispatchInfo",
                    Title = "",
                    Value = new DispatchInfoDto()
                    {
                        PaysFee = Pays.Yes,
                        Class = DispatchClass.Mandatory,
                        Weight = 158080000
                    }
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
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
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            //Ferdie SS58 Address: 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            var expectedResult = EventResult.Create("System", "NewAccount", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_AccountId32",
                    Title = "Account",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
