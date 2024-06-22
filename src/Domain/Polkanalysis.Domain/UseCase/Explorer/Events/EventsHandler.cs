using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Explorer.Events
{
    public class EventsHandler : Handler<EventsHandler, IEnumerable<EventDto>, EventsQuery>
    {
        private readonly IExplorerService _explorerRepository;

        public EventsHandler(
            IExplorerService explorerRepository,
            ILogger<EventsHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _explorerRepository = explorerRepository;
        }

        public async override Task<Result<IEnumerable<EventDto>, ErrorResult>> HandleInnerAsync(EventsQuery request, CancellationToken cancellationToken)
        {
            var result = await _explorerRepository.GetEventsAsync(request.BlockId, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
