using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using PolkadotRuntime = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using ScheduleEvent = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums;
using SystemEvent = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Tests.Runtime.Event
{
    public class ScheduleEventListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L253
        /// Pallet scheduler
        /// Schedule time
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x020100CE41E9000000000000")]
        public void Scheduler_ScheduleBlock_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);

            PrerequisiteEvent(nodeResult, SystemEvent.Phase.Initialization);

            Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.Scheduler));
            Assert.That(nodeResult.Method, Is.EqualTo(ScheduleEvent.Event.Scheduled));

            //var result = EventResult.Create(nodeResult);
            //Assert.IsNotNull(result);

            //var expectedResult = EventResult.Create("Scheduler", "Scheduled", new List<EventDetailsResult>()
            //{
            //    new EventDetailsResult()
            //    {
            //        ComponentName = "Component_U32",
            //        Title = "BlockNumber",
            //        Value = (uint)400
            //    },
            //    new EventDetailsResult()
            //    {
            //        ComponentName = "Component_U32",
            //        Title = "Index",
            //        Value = (uint)0
            //    },
            //});

            //Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L259
        /// Pallet scheduler
        /// Dispatch
	    /// result: DispatchResult = 0 (Ok)
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x0201021D5DE200000000000164656D6F63726163650000000000000000000000000000000000000000000000010200")]
        public void Scheduler_Dispatched_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            PrerequisiteEvent(nodeResult, SystemEvent.Phase.Initialization);

            Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.Scheduler));
            Assert.That(nodeResult.Method, Is.EqualTo(ScheduleEvent.Event.Dispatched));
        }
    }
}
