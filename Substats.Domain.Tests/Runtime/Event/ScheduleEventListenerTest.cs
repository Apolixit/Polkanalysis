using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Runtime;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Substats.Domain.Contracts.Runtime.Module;

namespace Substats.Domain.Tests.Runtime.Event
{
    public class ScheduleEventListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateNodeRepository>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L253
        /// Pallet scheduler
        /// Schedule time
        /// Block 400 
        /// Index : 0
        /// </summary>
        /// <param name="hex"></param>
        [Test, Ignore("TODO change with another call")]
        [TestCase("0x00010000000600900100000000000000")]
        public void Scheduler_ScheduleBlock_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("Scheduler", "Scheduled", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_U32",
                    Title = "BlockNumber",
                    Value = (uint)400
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_U32",
                    Title = "Index",
                    Value = (uint)0
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L259
        /// Pallet scheduler
        /// Dispatch
        /// task: TaskAddress<T::BlockNumber> = (180, 0)
        /// id: Option<TaskName> = Option<Bytes> 0x6d6f6e6579706f74396cdbf0a89f28e8ff09a5d97fae185d3ff9920d8cbcb3cec50f256865dbe0f1
	    /// result: DispatchResult = 0 (Ok)
        /// </summary>
        /// <param name="hex"></param>
        [Test, Ignore("TODO change with another call")]
        [TestCase("0x020602B40000000000000001A06D6F6E6579706F74396CDBF0A89F28E8FF09A5D97FAE185D3FF9920D8CBCB3CEC50F256865DBE0F10000")]
        public void Scheduler_Dispatched_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.Scheduler));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_scheduler.pallet.Event.Dispatched));
        }
    }
}
