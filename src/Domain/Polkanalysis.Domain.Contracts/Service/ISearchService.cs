using Polkanalysis.Domain.Contracts.Dto.Search;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResultDto>> SearchAsync(string query, CancellationToken token);
        Task<IEnumerable<SearchType>> TryDefineSearchTypeAsync(string query, CancellationToken token);
    }

    public enum SearchType
    {
        BlockHash,
        BlockNumber,
        Account,
    }
}