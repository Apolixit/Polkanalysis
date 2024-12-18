using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Database.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Service;
using NSubstitute.ReturnsExtensions;
using static Polkanalysis.Domain.Contracts.Primary.Result.ErrorResult;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Errors;
using Polkanalysis.Domain.Contracts.Metrics;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Algolia.Search.Models.Common;
using System.Threading;
using NSubstitute.ExceptionExtensions;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using System.Diagnostics;
using Substrate.NetApi.Model.Meta;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polkanalysis.Hub;
using Microsoft.Extensions.Caching.Hybrid;

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
            _serviceProvider.GetService(typeof(BalancesDustLostRepository)).Returns(new BalancesDustLostRepository(_substrateDbContext, _substrateService, Substitute.For<IHubConnection>(),Substitute.For<ILogger<BalancesDustLostRepository>>()));
            _serviceProvider.GetService(typeof(SystemKilledAccountRepository)).Returns(new SystemKilledAccountRepository(_substrateDbContext, _substrateService, Substitute.For<IHubConnection>(), Substitute.For<ILogger<SystemKilledAccountRepository>>()));

            _eventsFactory = new EventsFactory(_serviceProvider, Substitute.For<ILogger<IEventsFactory>>());
            _substrateService.BlockchainName.Returns("Polkadot");
            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), CancellationToken.None).Returns(MockHash);
            _coreService.GetDateTimeFromTimestampAsync(MockHash, CancellationToken.None).Returns(new DateTime(2024, 1, 1));
            _substrateService.At(Arg.Any<Hash>()).GetMetadataAsync(CancellationToken.None).ReturnsNull();

            var configuration = Substitute.For<IConfiguration>();
            configuration["Worker:EventsConfig:SaveAllEvents"].Returns("true");

            _useCase = new SavedEventsHandler(_substrateService,
                                              _eventsFactory,
                                              _logger,
                                              Substitute.For<HybridCache>(),
                                              _substrateDbContext,
                                              _substrateDecoding,
                                              _domainMetrics,
                                              _coreService,
                                              configuration);
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

            firstEvent.Create(phase, new Infrastructure.Blockchain.Contracts.Core.Maybe<EnumRuntimeEvent>(core: runtimeEvent), topics);

            // Not mapped
            firstEvent.Event.Value = null;
            //firstEvent.Event.Core = runtimeEvent;

            return firstEvent;
        }

        private static IEventNode buildCodeUpdatedNode()
        {
            var eventNode = Substitute.For<IEventNode>();
            eventNode.Module.Returns(RuntimeEvent.System);
            eventNode.Method.Returns(Event.CodeUpdated);
            return eventNode;
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
            IEventNode codeUpdateNode = buildCodeUpdatedNode();

            _substrateDecoding.DecodeEventAsync(codeUpdatedtEvent, null!, CancellationToken.None).Returns(codeUpdateNode);

            // No events
            _substrateService.At(Arg.Any<Hash>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([codeUpdatedtEvent])    
            );

            var result = await _useCase!.Handle(new SavedEventsCommand(new BlockNumber(1)), CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            var firstEvent = _substrateDbContext.EventsInformation.FirstOrDefault();
            Assert.That(firstEvent, Is.Not.Null);

            Assert.That(firstEvent.BlockId, Is.EqualTo(1));
        }

        /// <summary>
        /// Events cannot be decoded by NetApi.Ext project (can happen for old metadatas), should log and fail
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task SavedEventHandler_WithErrorInApiExt_ShouldLogAndFailAsync()
        {
            // No events
            _substrateService.At(MockHash).Storage.System.EventsAsync(CancellationToken.None).ThrowsAsync(new Exception("Error"));
            _substrateService.Rpc.State.GetRuntimeVersionAsync(MockHash, CancellationToken.None).Returns(new Substrate.NetApi.Model.Rpc.RuntimeVersion() { SpecVersion = 10 });
            _substrateService.NetApiExtAssembly.Returns("Polkanalysis.Polkadot.NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

            var result = await _useCase!.Handle(new SavedEventsCommand(new BlockNumber(1)), CancellationToken.None);

            Assert.That(result.IsSuccess, Is.False);

            var firstError = _substrateDbContext.SubstrateErrors.FirstOrDefault();
            Assert.That(firstError, Is.Not.Null);

            Assert.That(firstError.BlockNumber, Is.EqualTo(1));
            Assert.That(firstError.TypeError, Is.EqualTo(TypeErrorModel.EventsExt));
        }

        [Test]
        public async Task SavedEventHandler_WithValidData_ShouldSucceedAsync()
        {
            EventRecord killedAccountEvent = buildKilledAccountEvent();
            EventRecord newAccountEvent = buildNewAccountEvent();
            IEventNode killedAccountNode = buildKilledAccountNode();
            IEventNode newAccountNode = buildNewAccountNode();


            _substrateService.At(Arg.Any<Hash>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([killedAccountEvent, newAccountEvent]));

            _substrateDecoding.DecodeEventAsync(killedAccountEvent, null!, CancellationToken.None).Returns(killedAccountNode);
            _substrateDecoding.DecodeEventAsync(newAccountEvent, null!, CancellationToken.None).Returns(newAccountNode);

            var command = new SavedEventsCommand(new BlockNumber(1));

            Assert.That(_substrateDbContext.EventSystemKilledAccount.Count(), Is.EqualTo(0));
            Assert.That(_substrateDbContext.EventManager.Count(), Is.EqualTo(0));

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            Assert.That(_substrateDbContext.EventSystemKilledAccount.Count(), Is.EqualTo(1));
            Assert.That(_substrateDbContext.EventManager.Count(), Is.EqualTo(2));

            var dbEvent = _substrateDbContext.EventManager.Single(x => x.ModuleEvent == "KilledAccount");
            Assert.That(dbEvent.LastScanBlockId, Is.EqualTo(1));
            Assert.That(dbEvent.LastOccurenceScannedBlockId, Is.EqualTo(1));
        }

        [Test]
        public async Task SavedEventHandler_WithAlreadyInsertedData_ShouldUpdateAsync()
        {
            EventRecord killedAccountEvent = buildKilledAccountEvent();
            IEventNode killedAccountNode = buildKilledAccountNode();

            _substrateService.At(Arg.Any<Hash>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([killedAccountEvent]));

            _substrateDecoding.DecodeEventAsync(killedAccountEvent, null!, CancellationToken.None).Returns(killedAccountNode);

            var command = new SavedEventsCommand(new BlockNumber(1));
            var result = await _useCase!.Handle(command, CancellationToken.None);
            
            Assert.That(result.IsSuccess);
            Assert.That(_substrateDbContext.EventsInformation.Count(), Is.EqualTo(1));
            Assert.That(_substrateDbContext.EventsInformation.First().BlockDate, Is.EqualTo(new DateTime(2024, 1, 1)));

            // Then call it again with some differences to trigger update
            _coreService.GetDateTimeFromTimestampAsync(MockHash, CancellationToken.None).Returns(new DateTime(2024, 2, 2));

            result = await _useCase!.Handle(command, CancellationToken.None);
            Assert.That(result.IsSuccess);
            Assert.That(_substrateDbContext.EventsInformation.Count(), Is.EqualTo(1));
            Assert.That(_substrateDbContext.EventsInformation.First().BlockDate, Is.EqualTo(new DateTime(2024, 2, 2)));
        }

        [Test]
        public async Task SavedEventHandler_WithDbUpdateException_ShouldAddBusinessErrorAsync()
        {
            EventRecord killedAccountEvent = buildKilledAccountEvent();

            _substrateService.At(Arg.Any<Hash>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([killedAccountEvent]));
            _substrateDecoding.DecodeEventAsync(killedAccountEvent, null!, CancellationToken.None).ThrowsAsync(new DbUpdateException());
            var command = new SavedEventsCommand(new BlockNumber(1));

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public async Task SavedEventHandler_WithException_ShouldAddBusinessErrorAsync()
        {
            EventRecord killedAccountEvent = buildKilledAccountEvent();

            _substrateService.At(Arg.Any<Hash>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([killedAccountEvent]));
            _substrateDecoding.DecodeEventAsync(killedAccountEvent, null!, CancellationToken.None).ThrowsAsync(new Exception());

            var command = new SavedEventsCommand(new BlockNumber(1));

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.False);
        }
    }
}
