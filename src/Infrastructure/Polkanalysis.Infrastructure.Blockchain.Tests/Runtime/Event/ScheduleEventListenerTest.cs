using Microsoft.Extensions.Logging;
using NSubstitute;
using PolkadotRuntime = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using ScheduleEvent = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums;
using SystemEvent = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

namespace Polkanalysis.Domain.Tests.Runtime.Event
{
    public class ScheduleEventListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;
        private ILogger<SubstrateDecoding> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SubstrateDecoding>>();

            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                _logger);
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L259
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L253
        /// Pallet scheduler
        /// Dispatch
	    /// result: DispatchResult = 0 (Ok)
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x020100CE41E9000000000000", ScheduleEvent.Event.Scheduled)]
        [TestCase("0x0201021D5DE200000000000164656D6F63726163650000000000000000000000000000000000000000000000010200", ScheduleEvent.Event.Dispatched)]
        public async Task Scheduler_Dispatched_ShouldBeParsedAsync(string hex, ScheduleEvent.Event schedulerEvent)
        {
            var nodeResult = await _substrateDecode.DecodeEventAsync(hex, CancellationToken.None);
            PrerequisiteEvent(nodeResult, SystemEvent.Phase.Initialization);

            Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.Scheduler));
            Assert.That(nodeResult.Method, Is.EqualTo(schedulerEvent));
        }
    }
}
