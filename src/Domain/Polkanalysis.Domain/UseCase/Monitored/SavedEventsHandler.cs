using FluentValidation;
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
            // Is this event has to be insert in database ?
            var eventFound = _eventsFactory.TryFind(request.EventNode.Module, request.EventNode.Method);
            if (eventFound is null)
            {
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"{request.EventNode.Module} | {request.EventNode.Method} is not linked to the database");
            }

            var databaseModel = new EventModel(
                _polkadotRepository.BlockchainName,
                request.BlockNumber.Value,
                request.CurrentDate,
                request.EventIndex,
                request.GetModuleName(),
                request.GetEventName());

            var subEvent = (BaseEnumType)request.Ev.Event.Value!;

            await _eventsFactory.ExecuteInsertAsync(
                request.GetRuntimeEvent(),
                request.GetRuntimeMethod(),
                databaseModel,
                subEvent.GetValue2(),
                cancellationToken);

            LogEventManager((int)request.BlockNumber.Value,
                            (int)request.BlockNumber.Value,
                            eventFound.GetModule().moduleName,
                            eventFound.GetModule().moduleEvent);

            // Every 1000 blocks, insert events into EventManager table to keep track of analyzed events
            if (request.BlockNumber.Value % 1000 == 0)
            {
                _logger.LogInformation($"Block number % 1000. Insert events into EventManager table.");
                foreach (var mapped in _eventsFactory.Mapped)
                {
                    LogEventManager(null,
                            (int)request.BlockNumber.Value,
                            mapped.GetModule().moduleName,
                            mapped.GetModule().moduleEvent);
                }
            }

            _dbContext.SaveChanges();

            return Helpers.Ok(true);
        }

        /// <summary>
        /// Log the event into the EventManager table to keep track of scanned events
        /// </summary>
        /// <param name="lastOccurence"></param>
        /// <param name="lastScan"></param>
        /// <param name="moduleName"></param>
        /// <param name="moduleEvent"></param>
        private void LogEventManager(int? lastOccurence, int lastScan, string moduleName, string moduleEvent)
        {
            var model = new EventManagerModel()
            {
                BlockchainName = _polkadotRepository.BlockchainName,
                LastScanBlockId = lastScan,
                ModuleName = moduleName,
                ModuleEvent = moduleEvent,
            };
            if (lastOccurence is not null)
                model.LastOccurenceScannedBlockId = lastOccurence.Value;

            if(!_dbContext.EventManagerModel.Any(x => x.BlockchainName == model.BlockchainName && x.ModuleName == model.ModuleName && x.ModuleEvent == model.ModuleEvent))
                _dbContext.EventManagerModel.Add(model);
            else
                _dbContext.EventManagerModel.Update(model);
        }
    }
}
