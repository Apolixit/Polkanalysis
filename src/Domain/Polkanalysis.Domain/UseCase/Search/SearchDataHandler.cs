using Algolia.Search.Clients;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Search;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Domain.UseCase.Search
{
    public class SearchHandler : Handler<SearchHandler, IEnumerable<SearchResultDto>, SearchQuery>
    {
        //private readonly ISearchClient _searchClient;
        private readonly SubstrateDbContext _context;

        public SearchHandler(ILogger<SearchHandler> logger, IDistributedCache cache, /*ISearchClient searchClient,*/ SubstrateDbContext context) : base(logger, cache)
        {
            //_searchClient = searchClient;
            _context = context;
        }

        public override Task<Result<IEnumerable<SearchResultDto>, ErrorResult>> HandleInnerAsync(SearchQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    //public class SearchCommandHandler : Handler<SearchCommandHandler, bool, SearchCommand>
    //{
    //    private readonly ISearchClient _searchClient;
    //    private readonly SubstrateDbContext _context;

    //    public SearchCommandHandler(ILogger<SearchCommandHandler> logger, IDistributedCache cache, ISearchClient searchClient, SubstrateDbContext context) : base(logger, cache)
    //    {
    //        _searchClient = searchClient;
    //        _context = context;
    //    }

    //    public override Task<Result<IEnumerable<SearchResultDto>, ErrorResult>> HandleInnerAsync(SearchCommand request, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
