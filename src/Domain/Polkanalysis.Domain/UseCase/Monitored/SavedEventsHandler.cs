using Algolia.Search.Models.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Metrics;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Metrics;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NET.Utils;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using System.Threading;

namespace Polkanalysis.Domain.UseCase.Monitored
{
    public class SavedEventsCommandValidator : AbstractValidator<SavedEventsCommand>
    {
        public SavedEventsCommandValidator(ISubstrateService substrateRepository)
        {
            RuleFor(x => x.BlockNumber.Value)
                .GreaterThan((uint)0)
                .MustAsync(async (x, token) =>
                {
                    // The block number must be less than or equal to the current block number
                    var blockNum = await substrateRepository.Rpc.Chain.GetHeaderAsync(token);
                    return x <= blockNum.Number.Value;
                });

            //RuleFor(x => x.EventNode).NotEmpty();
            //RuleFor(x => x.CurrentDate).LessThanOrEqualTo(DateTime.Now);
            //RuleFor(x => x.Ev).NotNull();
        }
    }

    public class SavedEventsHandler : Handler<SavedEventsHandler, bool, SavedEventsCommand>
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IEventsFactory _eventsFactory;
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IDomainMetrics _domainMetrics;
        private readonly IExplorerService _explorerRepository;

        public SavedEventsHandler(ISubstrateService polkadotRepository, IEventsFactory eventsFactory, ILogger<SavedEventsHandler> logger, IDistributedCache cache, SubstrateDbContext dbContext, ISubstrateDecoding substrateDecode, IDomainMetrics domainMetrics, IExplorerService explorerRepository) : base(logger, cache)
        {
            _polkadotRepository = polkadotRepository;
            _eventsFactory = eventsFactory;
            _dbContext = dbContext;
            _substrateDecode = substrateDecode;
            _domainMetrics = domainMetrics;
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(SavedEventsCommand request, CancellationToken cancellationToken)
        {
            // Get events associated at each block
            var events = await _polkadotRepository.At(request.BlockNumber).Storage.System.EventsAsync(cancellationToken);

            if (events == null)
            {
                _logger.LogWarning("[{handler}] No events associated to block num {blockId}", nameof(SavedEventsHandler), request.BlockNumber);

                return UseCaseError(ErrorResult.ErrorType.NoNeedToProcess, $"No events associated to block num {request.BlockNumber}", ErrorResult.ErrorCriticity.Low);
            }

            var currentDate = await _explorerRepository.GetDateTimeFromTimestampAsync(request.BlockNumber, cancellationToken);

            _logger.LogInformation("[{handler}] Scan block num {blockNumber}, associated events = {eventsCount}", nameof(SavedEventsHandler), request.BlockNumber, events.Value.Length);

            var ratio = PushEventAnalyzedByBlockRatio(events);

            for (int i = 0; i < events.Value.Length; i++)
            {
                var ev = events.Value[i];

                if (!ev.Event.HasBeenMapped)
                {
                    await LogUnmappedEventAsync(request, currentDate, i, ev, cancellationToken);
                    continue;
                }

                try
                {
                    var eventNode = _substrateDecode.DecodeEvent(ev);
                    var eventFound = _eventsFactory.TryFind(eventNode.Module, eventNode.Method);

                    // Is this event has to be insert in database ?
                    if (eventFound is null)
                    {
                        _logger.LogDebug("[{handler}][{module}][{method}] has no database event linked", nameof(SavedEventsHandler), eventNode.Module, eventNode.Method);
                        continue;
                    }

                    _logger.LogInformation("[{handler}][{module}][{method}] is linked to database. Ratio = {ratio}", nameof(SavedEventsHandler), eventNode.Module, eventNode.Method, ratio);

                    await InsertDatabaseAsync(request.BlockNumber, currentDate, (uint)i, ev, eventNode, eventFound, cancellationToken);

                    _domainMetrics.IncreaseAnalyzedEventsCount();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "[{handler}] Unable to successfully decode event index {eventIndex} from block {blockNum}. Event value = ({eventHex}). Ratio = {ratio}", nameof(SavedEventsHandler), i, request.BlockNumber, Utils.Bytes2HexString(ev.Bytes), ratio);
                }
            }

            return Helpers.Ok(true);
        }

        /// <summary>
        /// Log unmapped events and push them to the database to keep track and allow to re-run them in the futur
        /// </summary>
        /// <param name="request"></param>
        /// <param name="currentDate"></param>
        /// <param name="i"></param>
        /// <param name="ev"></param>
        private async Task LogUnmappedEventAsync(SavedEventsCommand request, DateTime currentDate, int i, EventRecord ev, CancellationToken cancellationToken)
        {
            _logger.LogWarning("[{handler}] Event index {eventIndex} from block {blockNumber} has not been mapped, please check the mapper (core type / value : {eventCoreType} / {eventHex})",
                               nameof(SavedEventsHandler),
                               i,
                               request.BlockNumber,
                               ev.Event.CoreType.Name,
                               Utils.Bytes2HexString(ev.Event.Core!.Encode()));

            _dbContext.SubstrateErrors.Add(new Infrastructure.Database.Contracts.Model.Errors.SubstrateErrorModel()
            {
                BlockchainName = _polkadotRepository.BlockchainName,
                BlockNumber = request.BlockNumber.Value,
                Date = currentDate,
                TypeError = Infrastructure.Database.Contracts.Model.Errors.TypeErrorModel.Events,
                ElementId = (uint)i,
                Message = $"Event index {i} from block {request.BlockNumber} has not been mapped, please check the mapper (core type / value : {ev.Event.CoreType.Name} / {Utils.Bytes2HexString(ev.Event.Core!.Encode())})"
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Insert event into EventManager table to keep track
        /// </summary>
        /// <param name="lastOccurence"></param>
        /// <param name="lastScan"></param>
        /// <param name="moduleName"></param>
        /// <param name="moduleEvent"></param>
        private void LogEventManager(int? lastOccurence, int lastScan, string moduleName, string moduleEvent)
        {
            var model = new EventManagerModel
            {
                BlockchainName = _polkadotRepository.BlockchainName,
                LastScanBlockId = lastScan,
                ModuleName = moduleName,
                ModuleEvent = moduleEvent,
                LastOccurenceScannedBlockId = lastOccurence ?? 0 // Assuming default value for LastOccurenceScannedBlockId is 0
            };

            var existingModel = _dbContext.EventManager
                .FirstOrDefault(x => x.BlockchainName == model.BlockchainName && x.ModuleName == model.ModuleName && x.ModuleEvent == model.ModuleEvent);

            if (existingModel == null)
            {
                _dbContext.EventManager.Add(model);
            }
            else
            {
                existingModel.LastScanBlockId = model.LastScanBlockId;
                existingModel.LastOccurenceScannedBlockId = model.LastOccurenceScannedBlockId;
            }
        }

        /// <summary>
        /// Get the ratio of events that has been analyzed compare to the total number of events
        /// </summary>
        /// <param name="events"></param>
        private double PushEventAnalyzedByBlockRatio(BaseVec<EventRecord> events)
        {
            var mappedRatio = (double)events.Value.Where(x => x.Event.HasBeenMapped).Count() / (double)events.Value.Count();
            _domainMetrics.RecordEventAnalyzed(mappedRatio);

            return mappedRatio;
        }

        private async Task InsertDatabaseAsync(
            BlockNumber blockNumber,
            DateTime currentDate,
            uint eventIndex,
            EventRecord ev,
            IEventNode eventNode,
            EventElementFactory eventFound,
            CancellationToken cancellationToken)
        {
            var moduleName = eventNode.Module.ToString();
            var eventName = eventNode.Method.ToString();
            var blockchainName = _polkadotRepository.BlockchainName;

            var alreadyInserted = await _dbContext.EventManager
                .FirstOrDefaultAsync(x =>
                    x.BlockchainName == blockchainName &&
                x.ModuleName == moduleName &&
                x.ModuleEvent == eventName, cancellationToken);

            if (alreadyInserted != null && alreadyInserted.LastOccurenceScannedBlockId >= blockNumber.Value)
                return;

            var databaseModel = new EventModel(
                blockchainName,
                blockNumber.Value,
                currentDate,
                eventIndex,
            moduleName,
            eventName);

            var subEvent = (BaseEnumType)ev.Event.Value!;
            await _eventsFactory.ExecuteInsertAsync(
            eventNode.Module,
                eventNode.Method,
                databaseModel,
                subEvent.GetValue2(),
            cancellationToken);

            LogEventManager((int)blockNumber.Value,
                            (int)blockNumber.Value,
                            moduleName,
            eventName);

            if (blockNumber.Value % 1000 == 0)
            {
                _logger.LogInformation("[{handler}] Block number {blockNum} % 1000. Insert events into EventManager table.", nameof(SavedEventsHandler), blockNumber.Value);
                foreach (var mapped in _eventsFactory.Mapped)
                {
                    LogEventManager(null, (int)blockNumber.Value, mapped.GetModule().moduleName, mapped.GetModule().moduleEvent);
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
