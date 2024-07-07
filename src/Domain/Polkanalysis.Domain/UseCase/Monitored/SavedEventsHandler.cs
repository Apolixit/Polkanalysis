using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base;

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

            RuleFor(x => x.EventNode).NotEmpty();
            RuleFor(x => x.CurrentDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Ev).NotNull();
        }
    }

    public class SavedEventsHandler : Handler<SavedEventsHandler, bool, SavedEventsCommand>
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IEventsFactory _eventsFactory;
        private readonly SubstrateDbContext _dbContext;

        public SavedEventsHandler(ISubstrateService polkadotRepository, IEventsFactory eventsFactory, ILogger<SavedEventsHandler> logger, IDistributedCache cache, SubstrateDbContext dbContext) : base(logger, cache)
        {
            _polkadotRepository = polkadotRepository;
            _eventsFactory = eventsFactory;
            _dbContext = dbContext;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(SavedEventsCommand request, CancellationToken cancellationToken)
        {
            var eventFound = _eventsFactory.TryFind(request.EventNode.Module, request.EventNode.Method);
            if (eventFound is null)
            {
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"{request.EventNode.Module} | {request.EventNode.Method} is not linked to the database");
            }

            var moduleName = request.GetModuleName();
            var eventName = request.GetEventName();
            var blockchainName = _polkadotRepository.BlockchainName;

            var alreadyInserted = await _dbContext.EventManagerModel
                .FirstOrDefaultAsync(x =>
                    x.BlockchainName == blockchainName &&
                    x.ModuleName == moduleName &&
                    x.ModuleEvent == eventName, cancellationToken);

            if(alreadyInserted != null && alreadyInserted.LastOccurenceScannedBlockId >= request.BlockNumber.Value)
            {
                return Helpers.Ok(true);
            }

            var databaseModel = new EventModel(
                blockchainName,
                request.BlockNumber.Value,
                request.CurrentDate,
                request.EventIndex,
                moduleName,
                eventName);

            var subEvent = (BaseEnumType)request.Ev.Event.Value!;
            await _eventsFactory.ExecuteInsertAsync(
                request.GetRuntimeEvent(),
                request.GetRuntimeMethod(),
                databaseModel,
                subEvent.GetValue2(),
                cancellationToken);

            LogEventManager((int)request.BlockNumber.Value,
                            (int)request.BlockNumber.Value,
                            moduleName,
                            eventName);

            //if (alreadyInserted == null)
            //{
            //    alreadyInserted = new EventManagerModel
            //    {
            //        BlockchainName = blockchainName,
            //        ModuleName = moduleName,
            //        ModuleEvent = eventName,
            //        LastOccurenceScannedBlockId = (int)request.BlockNumber.Value
            //    };
            //    _dbContext.EventManagerModel.Add(alreadyInserted);
            //}
            //else
            //{
            //    alreadyInserted.LastOccurenceScannedBlockId = (int)request.BlockNumber.Value;
            //}

            if (request.BlockNumber.Value % 1000 == 0)
            {
                _logger.LogInformation("Block number {blockNum} % 1000. Insert events into EventManager table.", request.BlockNumber.Value);
                foreach (var mapped in _eventsFactory.Mapped)
                {
                    LogEventManager(null, (int)request.BlockNumber.Value, mapped.GetModule().moduleName, mapped.GetModule().moduleEvent);
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Helpers.Ok(true);
        }

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

            var existingModel = _dbContext.EventManagerModel
                .FirstOrDefault(x => x.BlockchainName == model.BlockchainName && x.ModuleName == model.ModuleName && x.ModuleEvent == model.ModuleEvent);

            if (existingModel == null)
            {
                _dbContext.EventManagerModel.Add(model);
            }
            else
            {
                existingModel.LastScanBlockId = model.LastScanBlockId;
                existingModel.LastOccurenceScannedBlockId = model.LastOccurenceScannedBlockId;
            }
        }
    }
}
