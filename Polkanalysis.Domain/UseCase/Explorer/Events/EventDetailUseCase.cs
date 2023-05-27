using Polkanalysis.Domain.Contracts.Dto.Event;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;

namespace Polkanalysis.Domain.UseCase.Explorer.Events
{
    public class EventDetailUseCase : UseCase<EventDetailUseCase, EventDto, EventDetailQuery>
    {
        private readonly IExplorerRepository _explorerRepository;


        public EventDetailUseCase(
            IExplorerRepository explorerRepository,
            ILogger<EventDetailUseCase> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public override async Task<Result<EventDto, ErrorResult>> Handle(EventDetailQuery command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            if(command.BlockNumber < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(command.BlockNumber)} is not valid (should be > 0)");

            if (command.EventIndex < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(command.EventIndex)} is not valid (should be > 0)");


            EventDto eventDto = await _explorerRepository.GetEventAsync(command.BlockNumber, command.EventIndex, cancellationToken);

            if (eventDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(eventDto)} is null");

            _logger.LogInformation($"{nameof(eventDto)} has been succesfully created.");
            return Helpers.Ok(eventDto);
        }
    }
}