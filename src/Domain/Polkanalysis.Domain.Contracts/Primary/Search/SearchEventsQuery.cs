using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Search
{
    public class SearchEventsQuery : IRequest<Result<IQueryable<EventsResultDto>, ErrorResult>>
    {
        public IEnumerable<string> SelectedModules { get; set; } = new List<string>();
        public IEnumerable<string> SelectedEvents { get; set; } = new List<string>();
        public NumberCriteria<uint>? NumberBlockFilter { get; set; }
        public NumberCriteria<DateTime>? DateBlockFilter { get; set; }
    }
}
