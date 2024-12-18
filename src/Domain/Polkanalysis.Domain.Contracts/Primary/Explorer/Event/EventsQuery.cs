using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Event
{
    public class EventsQuery : IRequest<Result<IEnumerable<EventDto>, ErrorResult>>
    {
        public uint BlockNumber { get; set; }
    }
}
