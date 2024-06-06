using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
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

            RuleFor(x => x.EventIndex).GreaterThanOrEqualTo(0);
            RuleFor(x => x.EventNode).NotEmpty();
            RuleFor(x => x.CurrentDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Ev).NotNull();
        }
    }

    public class SavedEventsHandler : Handler<SavedEventsHandler, bool, SavedEventsCommand>
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IEventsFactory _eventsFactory;

        public SavedEventsHandler(ISubstrateService polkadotRepository, IEventsFactory eventsFactory, ILogger<SavedEventsHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _polkadotRepository = polkadotRepository;
            _eventsFactory = eventsFactory;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(SavedEventsCommand request, CancellationToken cancellationToken)
        {
            // Is this event has to be insert in database ?
            if (!_eventsFactory.Has(request.EventNode.Module, request.EventNode.Method))
            {
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"{request.EventNode.Module} | {request.EventNode.Method} is not linked to the database");
            }

            var databaseModel = new EventModel(
                _polkadotRepository.BlockchainName,
                (int)request.BlockNumber.Value,
                request.CurrentDate,
                request.EventIndex,
                request.EventNode.Module.ToString(),
                request.EventNode.Method.ToString());

            var subEvent = (BaseEnumType)request.Ev.Event.Value!;

            await _eventsFactory.ExecuteInsertAsync(
                request.EventNode.Module,
                request.EventNode.Method,
                databaseModel,
                subEvent.GetValue2(), cancellationToken);

            return Helpers.Ok(true);
        }
    }
}
