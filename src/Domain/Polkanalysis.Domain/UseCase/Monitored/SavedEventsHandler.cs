﻿using Algolia.Search.Models.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Metrics;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Metrics;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NET.Utils;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using System.Diagnostics;
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
        }
    }

    public class SavedEventsHandler : Handler<SavedEventsHandler, bool, SavedEventsCommand>
    {
        private readonly ISubstrateService _substrateService;
        private readonly IEventsFactory _eventsFactory;
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly IDomainMetrics _domainMetrics;
        private readonly ICoreService _coreService;

        public SavedEventsHandler(ISubstrateService substrateService, IEventsFactory eventsFactory, ILogger<SavedEventsHandler> logger, IDistributedCache cache, SubstrateDbContext dbContext, ISubstrateDecoding substrateDecode, IDomainMetrics domainMetrics, ICoreService coreService) : base(logger, cache)
        {
            _substrateService = substrateService;
            _eventsFactory = eventsFactory;
            _dbContext = dbContext;
            _substrateDecode = substrateDecode;
            _domainMetrics = domainMetrics;
            _coreService = coreService;
        }

        /// <summary>
        /// Save events from a block into the database
        /// 
        /// There are 4 cases :
        ///     1. Events are not fetched correctly (NetApiExt failed, it can happen mostly with Metadata <v14). In this case, we log the error inside SubstrateErrorModel table, with a status TypeErrorModel.EventsExt and return a business error
        ///     2. Events are fetched, but not mapped to Polkanalysis.Infrastructure events (this is ok, we cannot handle everything). In this case, we log the raw event inside SubstrateErrorModel table, with a status TypeErrorModel.Events and return a valid business value
        ///     3. Events are fetched, mapped to Polkanalysis.Infrastructure events but there is not specific table for it. In this case, we log the mapped event (contrary to previous point with was raw event) inside SubstrateErrorModel table, with a status TypeErrorModel.Events and return a valid business value
        ///     4. Events are fetched, mapped to Polkanalysis.Infrastructure and have specific tables (<see cref="Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesTransferModel"/> or <see cref="Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools.NominationPoolsCreatedModel"/>) and event is inserted inside it own table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(SavedEventsCommand request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            var blockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(request.BlockNumber), cancellationToken);
            var currentDate = await _coreService.GetDateTimeFromTimestampAsync(blockHash, cancellationToken);

            // Get events associated at each block
            BaseVec<EventRecord>? events = null;
            try
            {
                events = await _substrateService.At(request.BlockNumber).Storage.System.EventsAsync(cancellationToken);
            }
            catch (Exception)
            {
                await LogInvalidEventExtAsync(request, currentDate, blockHash, cancellationToken);
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Unable to decode event from block num {request.BlockNumber}", ErrorResult.ErrorCriticity.High);
            }

            if (events == null)
            {
                _logger.LogWarning("[{handler}] No events associated to block num {blockId}", nameof(SavedEventsHandler), request.BlockNumber);

                return UseCaseError(ErrorResult.ErrorType.NoNeedToProcess, $"No events associated to block num {request.BlockNumber}", ErrorResult.ErrorCriticity.Low);
            }

            var ratio = PushEventAnalyzedByBlockRatio(events);

            for (int i = 0; i < events.Value.Length; i++)
            {
                var ev = events.Value[i];
                var eventNode = await _substrateDecode.DecodeEventAsync(ev, cancellationToken);

                await SaveEventAsync(request, currentDate, i, ev, eventNode, cancellationToken);

                try
                {
                    var eventFound = _eventsFactory.TryFind(eventNode.Module, eventNode.Method);

                    // Is this event has to be insert in database ?
                    if (eventFound is null)
                    {
                        _logger.LogDebug("[{handler}][{module}][{method}] has no database event linked", nameof(SavedEventsHandler), eventNode.Module, eventNode.Method);
                        continue;
                    }

                    _logger.LogDebug("[{handler}][{module}][{method}] is linked to database", nameof(SavedEventsHandler), eventNode.Module, eventNode.Method);

                    await InsertDatabaseAsync(request.BlockNumber, currentDate, (uint)i, ev, eventNode, eventFound, cancellationToken);

                    _domainMetrics.IncreaseAnalyzedEventsCount(_substrateService.BlockchainName);
                }
                catch(DbUpdateException ex)
                {
                    _logger.LogError(ex, "[{handler}][Block {blockNum}][Event {eventIndex}] EntityFramework exception. {message}", nameof(SavedEventsHandler), request.BlockNumber, i, ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "[{handler}] Unable to successfully decode event index {eventIndex} from block {blockNum}. Event value = ({eventHex}). Ratio = {ratio}", nameof(SavedEventsHandler), i, request.BlockNumber, Utils.Bytes2HexString(ev.Bytes), ratio);
                }
            }

            stopwatch.Stop();

            _logger.LogInformation("[{handler}] Sucessfully scan block num {blockNumber}, associated events {eventsCount} in {timeMs}ms", nameof(SavedEventsHandler), request.BlockNumber, events.Value.Length, stopwatch.Elapsed.TotalMilliseconds);

            _domainMetrics.RecordAverageTimeToAnalyzeEventsForEachBlock(stopwatch.Elapsed.TotalMilliseconds, _substrateService.BlockchainName);
            return Helpers.Ok(true);
        }

        /// <summary>
        /// Log events that fail to be get from the blockchain. It means that NET.API.Ext is invalid
        /// </summary>
        /// <param name="request"></param>
        /// <param name="currentDate"></param>
        /// <param name="i"></param>
        /// <param name="ev"></param>
        private async Task LogInvalidEventExtAsync(SavedEventsCommand request, DateTime currentDate, Hash blockHash, CancellationToken cancellationToken)
        {
            var specVersion = await _substrateService.Rpc.State.GetRuntimeVersionAsync(blockHash, cancellationToken);
            _logger.LogError("[{handler}] Events from block {blockNumber} (spec version {specVersion} has not been fetched because of an error inside {netApiExt}",
                               nameof(SavedEventsHandler),
                               request.BlockNumber,
                               _substrateService.NetApiExtAssembly,
                               specVersion.SpecVersion);

            _dbContext.SubstrateErrors.Add(new Infrastructure.Database.Contracts.Model.Errors.SubstrateErrorModel()
            {
                BlockchainName = _substrateService.BlockchainName,
                BlockNumber = request.BlockNumber.Value,
                Date = currentDate,
                TypeError = Infrastructure.Database.Contracts.Model.Errors.TypeErrorModel.EventsExt,
                ElementId = null,
                Message = $"Events from block {request.BlockNumber} (spec version {specVersion.SpecVersion}) has not been fetched because of an error inside {_substrateService.NetApiExtAssembly}"
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Save events to the database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="currentDate"></param>
        /// <param name="i"></param>
        /// <param name="ev"></param>
        private async Task SaveEventAsync(SavedEventsCommand request, DateTime currentDate, int i, EventRecord ev, IEventNode eventNode, CancellationToken cancellationToken)
        {
            if (!ev.Event.HasBeenMapped)
            {
                _logger.LogWarning("[{handler}] Event index {eventIndex} from block {blockNumber} has not been mapped, please check the mapper (core type / value : {eventCoreType} / {eventHex})",
                               nameof(SavedEventsHandler),
                               i,
                               request.BlockNumber,
                               ev.Event.CoreType.Name,
                               Utils.Bytes2HexString(ev.Event.Core!.Encode()));
            }

            _dbContext.EventsInformation.Add(new EventsInformationModel(
                _substrateService.BlockchainName,
                request.BlockNumber.Value,
               currentDate,
               (uint)i,
               eventNode.Module.ToString(),
               eventNode.Method.ToString(),
          eventNode.ToJson()
            ));

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Insert event into EventManager table to keep track
        /// </summary>
        /// <param name="lastOccurence"></param>
        /// <param name="lastScan"></param>
        /// <param name="moduleName"></param>
        /// <param name="moduleEvent"></param>
        private async Task LogEventManagerAsync(int? lastOccurence, int lastScan, string moduleName, string moduleEvent, CancellationToken cancellationToken)
        {
            var model = new EventManagerModel
            {
                BlockchainName = _substrateService.BlockchainName,
                LastScanBlockId = lastScan,
                ModuleName = moduleName,
                ModuleEvent = moduleEvent,
                LastOccurenceScannedBlockId = lastOccurence ?? 0 // Assuming default value for LastOccurenceScannedBlockId is 0
            };

            var existingModel = _dbContext.EventManager
                .FirstOrDefault(x => x.BlockchainName == model.BlockchainName && x.ModuleName == model.ModuleName && x.ModuleEvent == model.ModuleEvent);

            _logger.LogInformation("[{handler}][{method}] {typeOperation} {moduleName} {eventName}. Last scan {lastScan}, last occurrence = {lastOccurrence}", nameof(SavedEventsHandler), nameof(LogEventManagerAsync), existingModel is null ? "Insert" : "Update", moduleName, moduleEvent, lastOccurence?.ToString() ?? "never", lastScan);

            if (existingModel == null)
            {
                _dbContext.EventManager.Add(model);
            }
            else
            {
                existingModel.LastScanBlockId = model.LastScanBlockId;
                existingModel.LastOccurenceScannedBlockId = model.LastOccurenceScannedBlockId;
            }

            // I need to save now, because following function call LogEventManagerAsync again and I got EF Core "already tacking" error
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Get the ratio of events that has been analyzed compare to the total number of events
        /// </summary>
        /// <param name="events"></param>
        private double PushEventAnalyzedByBlockRatio(BaseVec<EventRecord> events)
        {
            var mappedRatio = (double)events.Value.Where(x => x.Event.HasBeenMapped).Count() / (double)events.Value.Count();
            _domainMetrics.RecordRatioEventAnalyzed(mappedRatio, _substrateService.BlockchainName);

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
            var blockchainName = _substrateService.BlockchainName;

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

            await LogEventManagerAsync((int)blockNumber.Value, (int)blockNumber.Value, moduleName, eventName, cancellationToken);

            if (blockNumber.Value % 1000 == 0)
            {
                _logger.LogInformation("[{handler}] Block number {blockNum} % 1000. Insert events into '{tableName}' table.",
                    nameof(SavedEventsHandler), blockNumber.Value, nameof(_dbContext.EventManager));
                foreach (var mapped in _eventsFactory.Mapped)
                {
                    await LogEventManagerAsync(null, (int)blockNumber.Value, mapped.GetModule().moduleName, mapped.GetModule().moduleEvent, cancellationToken);
                }
            }

            //await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
