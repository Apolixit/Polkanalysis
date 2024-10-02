using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Core.DispatchInfo;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Database.Repository;
using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Metrics;
using Polkanalysis.Domain.Contracts.Service;
using Algolia.Search.Models.Common;
using System.Threading;
using NSubstitute.ReturnsExtensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Polkanalysis.Domain.Contracts.Primary.Result.ErrorResult;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Errors;
using Polkanalysis.Domain.Contracts.Metrics;

namespace Polkanalysis.Domain.Tests.UseCase.Monitored
{
    public class SavedEventsHandlerTest : UseCaseTest<SavedEventsHandler, bool, SavedEventsCommand>
    {
        private IEventsFactory _eventsFactory;
        private IDomainMetrics _domainMetrics;
        private ICoreService _coreService;
        private ISubstrateDecoding _substrateDecoding;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SavedEventsHandler>>();
            _domainMetrics = Substitute.For<IDomainMetrics>();
            _coreService = Substitute.For<ICoreService>();
            _substrateDecoding = Substitute.For<ISubstrateDecoding>();


            var _serviceProvider = Substitute.For<IServiceProvider>();
            _serviceProvider.GetService(typeof(BalancesDustLostRepository)).Returns(new BalancesDustLostRepository(_substrateDbContext, _substrateService, Substitute.For<ILogger<BalancesDustLostRepository>>()));
            _serviceProvider.GetService(typeof(SystemKilledAccountRepository)).Returns(new SystemKilledAccountRepository(_substrateDbContext, _substrateService, Substitute.For<ILogger<SystemKilledAccountRepository>>()));

            _eventsFactory = new EventsFactory(_serviceProvider, Substitute.For<ILogger<IEventsFactory>>());

            _substrateService.BlockchainName.Returns("Polkadot");

            _useCase = new SavedEventsHandler(_substrateService,
                                              _eventsFactory,
                                              _logger,
                                              Substitute.For<IDistributedCache>(),
                                              _substrateDbContext,
                                              _substrateDecoding,
                                              _domainMetrics,
                                              _coreService);
        }

        /// <summary>
        /// Mock an unmapped CodeUpdated event
        /// </summary>
        /// <returns></returns>
        private EventRecord buildCodeUpdatedEvent()
        {
            var firstEvent = new EventRecord();
            var phase = new EnumPhase();
            phase.Create(Phase.ApplyExtrinsic, new U32(0));
            var topics = new BaseVec<Hash>();
            topics.Create(new byte[] { 0 });

            var runtimeEvent = new EnumRuntimeEvent();
            var codeUpdatedEvent = new EnumEvent();

            codeUpdatedEvent.Create(Event.CodeUpdated, new BaseVoid());
            runtimeEvent.Create(RuntimeEvent.System, codeUpdatedEvent);

            firstEvent.Create(phase, new Infrastructure.Blockchain.Contracts.Core.Maybe<EnumRuntimeEvent>(runtimeEvent), topics);
            // Not mapped
            firstEvent.Event.Value = null;
            firstEvent.Event.Core = runtimeEvent;

            return firstEvent;
        }

        private static IEventNode buildKilledAccountNode()
        {
            var eventNode = Substitute.For<IEventNode>();
            eventNode.Module.Returns(RuntimeEvent.System);
            eventNode.Method.Returns(Event.KilledAccount);
            return eventNode;
        }

        /// <summary>
        /// Mock a mapped KilledAccount event
        /// </summary>
        /// <returns></returns>
        private EventRecord buildKilledAccountEvent()
        {
            var firstEvent = new EventRecord();
            var phase = new EnumPhase();
            phase.Create(Phase.ApplyExtrinsic, new U32(0));
            var topics = new BaseVec<Hash>();
            topics.Create(new byte[] { 0 });

            var runtimeEvent = new EnumRuntimeEvent();
            var killedAccountEvent = new EnumEvent();

            killedAccountEvent.Create(Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.Event.KilledAccount, new SubstrateAccount(Alice.ToString()));
            runtimeEvent.Create(RuntimeEvent.System, killedAccountEvent);

            firstEvent.Create(phase, new Infrastructure.Blockchain.Contracts.Core.Maybe<EnumRuntimeEvent>(runtimeEvent), topics);
            return firstEvent;
        }

        /// <summary>
        /// Mock a mapped NewAccount event
        /// </summary>
        /// <returns></returns>
        private static IEventNode buildNewAccountNode()
        {
            var eventNode = Substitute.For<IEventNode>();
            eventNode.Module.Returns(RuntimeEvent.System);
            eventNode.Method.Returns(Event.NewAccount);
            return eventNode;
        }

        private EventRecord buildNewAccountEvent()
        {
            var firstEvent = new EventRecord();
            var phase = new EnumPhase();
            phase.Create(Phase.ApplyExtrinsic, new U32(0));
            var topics = new BaseVec<Hash>();
            topics.Create(new byte[] { 0 });

            var runtimeEvent = new EnumRuntimeEvent();
            var killedAccountEvent = new EnumEvent();

            killedAccountEvent.Create(Event.NewAccount, new SubstrateAccount(Alice.ToString()));
            runtimeEvent.Create(RuntimeEvent.System, killedAccountEvent);

            firstEvent.Create(phase, new Infrastructure.Blockchain.Contracts.Core.Maybe<EnumRuntimeEvent>(runtimeEvent), topics);
            return firstEvent;
        }

        /// <summary>
        /// Send invalid block number (> current block), validator should fail
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task SavedEventsCommandValidator_WithInvalidData_ShouldFailedAsync()
        {
            _substrateService.Rpc.Chain.GetHeaderAsync(CancellationToken.None)
                .Returns(new Substrate.NetApi.Model.Rpc.Header() { Number = new U64(100) });

            var command = new SavedEventsCommand(new BlockNumber(300));

            var validator = new SavedEventsCommandValidator(_substrateService);

            var result = await validator.ValidateAsync(command);

            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors.Count, Is.EqualTo(1));
        }

        /// <summary>
        /// Return no events, should be ignored
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task SavedEventHandler_WithNoEvents_ShouldBeIgnoredAsync()
        {
            // No events
            _substrateService.At(Arg.Any<BlockNumber>()).Storage.System.EventsAsync(CancellationToken.None).ReturnsNull();

            var result = await _useCase!.Handle(new SavedEventsCommand(new BlockNumber(1)), CancellationToken.None);

            Assert.That(result.IsError, Is.True);
            Assert.That(result.Error.Status, Is.EqualTo(ErrorType.NoNeedToProcess));
            Assert.That(result.Error.Criticity, Is.EqualTo(ErrorCriticity.Low));
        }

        /// <summary>
        /// Return only one unmapped event, should :
        /// 1. Be ignored (but return success)
        /// 2. Log the event into the logger
        /// 3. Insert this event into the database to keep track of this event (allow to re-run it in the futur when the event will be mapped)
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task SavedEventHandler_WithUnmappedEvents_ShouldLogAndSucceedAsync()
        {
            EventRecord codeUpdatedtEvent = buildCodeUpdatedEvent();

            // No events
            _substrateService.At(Arg.Any<BlockNumber>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([codeUpdatedtEvent])    
            );

            var result = await _useCase!.Handle(new SavedEventsCommand(new BlockNumber(1)), CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            var firstError = _substrateDbContext.SubstrateErrors.FirstOrDefault();
            Assert.That(firstError, Is.Not.Null);

            Assert.That(firstError.BlockNumber, Is.EqualTo(1));
            Assert.That(firstError.TypeError, Is.EqualTo(TypeErrorModel.Events));
        }

        [Test]
        public async Task SavedEventHandler_WithValidData_ShouldSucceedAsync()
        {
            EventRecord killedAccountEvent = buildKilledAccountEvent();
            EventRecord newAccountEvent = buildNewAccountEvent();
            IEventNode killedAccountNode = buildKilledAccountNode();
            IEventNode newAccountNode = buildNewAccountNode();


            _substrateService.At(Arg.Any<BlockNumber>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([killedAccountEvent, newAccountEvent]));

            _substrateDecoding.DecodeEvent(killedAccountEvent).Returns(killedAccountNode);
            _substrateDecoding.DecodeEvent(newAccountEvent).Returns(newAccountNode);

            var command = new SavedEventsCommand(new BlockNumber(1));

            Assert.That(_substrateDbContext.EventSystemKilledAccount.Count(), Is.EqualTo(0));
            Assert.That(_substrateDbContext.EventManager.Count(), Is.EqualTo(0));

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            Assert.That(_substrateDbContext.EventSystemKilledAccount.Count(), Is.EqualTo(1));
            Assert.That(_substrateDbContext.EventManager.Count(), Is.EqualTo(1));

            var dbEvent = _substrateDbContext.EventManager.Single(x => x.ModuleEvent == "KilledAccount");
            Assert.That(dbEvent.LastScanBlockId, Is.EqualTo(1));
            Assert.That(dbEvent.LastOccurenceScannedBlockId, Is.EqualTo(1));
        }
    }
}
