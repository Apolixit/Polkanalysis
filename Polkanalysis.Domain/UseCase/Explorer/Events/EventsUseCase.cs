using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Explorer.Events
{
    public class EventsUseCase : UseCase<EventsUseCase, IEnumerable<EventDto>, EventsQuery>
    {
        private readonly IExplorerRepository _explorerRepository;

        public EventsUseCase(
            IExplorerRepository explorerRepository,
            ILogger<EventsUseCase> logger) : base(logger)
        {
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<IEnumerable<EventDto>, ErrorResult>> Handle(EventsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _explorerRepository.GetEventsAsync(request.BlockId, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
