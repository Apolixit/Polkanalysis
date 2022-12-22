
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.SubstrateDecode.Abstract;
using Blazscan.SubstrateDecode.Event;
using NSubstitute;

namespace Blazscan.SubstrateDecode.Test.Event
{
    public class ScheduleEventListenerTest
    {
        private readonly ISubstrateDecoding _substrateDecode;

        public ScheduleEventListenerTest()
        {
            _substrateDecode = new SubstrateDecoding(Substitute.For<IMapping>(), Substitute.For<ISubstrateNodeRepository>(), Substitute.For<IPalletBuilder>());
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L253
        /// Pallet scheduler
        /// Schedule time
        /// Block 400 
        /// Index : 0
        /// </summary>
        /// <param name="hex"></param>
        [Test]
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
        [Test]
        [TestCase("0x020602B40000000000000001A06D6F6E6579706F74396CDBF0A89F28E8FF09A5D97FAE185D3FF9920D8CBCB3CEC50F256865DBE0F10000")]
        public void Scheduler_Dispatched_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("Scheduler", "Dispatched", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_Unknown",
                    Title = "BlockNumber",
                    Value = new List<int>() { 180, 0 }
                },
                new EventDetailsResult()
                {
                    ComponentName = "",
                    Title = "",
                    Value = "0xA06D6F6E6579706F74396CDBF0A89F28E8FF09A5D97FAE185D3FF9920D8CBCB3CEC50F256865DBE0F1"
                },
                new EventDetailsResult()
                {
                    ComponentName = "",
                    Title = "",
                    Value = "Ok"
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
