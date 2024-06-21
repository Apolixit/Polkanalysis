using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Search
{
    public class SearchQuery : IRequest<Result<IEnumerable<SearchResultDto>, ErrorResult>>
    {
        public SearchQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
