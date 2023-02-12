using Substats.Domain.Contracts.Dto;
using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.UseCase.Explorer.Block;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Contracts.Secondary.Repository;

namespace Substats.Domain.UseCase.Explorer.Events
{
    public class EventDetailUseCase : UseCase<EventDetailUseCase, EventDto, EventCommand>
    {
        private readonly IExplorerRepository _explorerRepository;

        public EventDetailUseCase(
            IExplorerRepository explorerRepository,
            ILogger<EventDetailUseCase> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public override async Task<Result<EventDto, ErrorResult>> ExecuteAsync(EventCommand eventCommand, CancellationToken cancellationToken)
        {
            if (eventCommand == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(eventCommand)} is not set");

            if(eventCommand.BlockNumber < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(eventCommand.BlockNumber)} is not valid (should be > 0)");

            if (eventCommand.EventIndex < 1)
                return UseCaseError(ErrorResult.ErrorType.InvalidParam, $"{nameof(eventCommand.EventIndex)} is not valid (should be > 0)");


            EventDto eventDto = await _explorerRepository.GetEventAsync(eventCommand.BlockNumber, eventCommand.EventIndex, cancellationToken);

            if (eventDto == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{nameof(eventDto)} is null");

            _logger.LogInformation($"{nameof(eventDto)} has been succesfully created.");
            return Helpers.Ok(eventDto);
        }
    }
}