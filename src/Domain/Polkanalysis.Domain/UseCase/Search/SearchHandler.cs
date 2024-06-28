using Algolia.Search.Clients;
using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Search;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Domain.UseCase.Search
{
    public class SearchQueryValidator : AbstractValidator<SearchQuery>
    {
        public SearchQueryValidator()
        {
            RuleFor(x => x.Query).NotEmpty();
        }
    }

    public class SearchHandler : Handler<SearchHandler, IEnumerable<SearchResultDto>, SearchQuery>
    {
        private readonly ISearchService _searchService;
        private readonly SubstrateDbContext _context;

        public SearchHandler(ILogger<SearchHandler> logger, IDistributedCache cache, ISearchService searchService, SubstrateDbContext context) : base(logger, cache)
        {
            _searchService = searchService;
            _context = context;
        }

        public override async Task<Result<IEnumerable<SearchResultDto>, ErrorResult>> HandleInnerAsync(SearchQuery request, CancellationToken cancellationToken)
        {
            var res = await _searchService.SearchAsync(request.Query, cancellationToken);

            return Helpers.Ok(res);
        }
    }
}
