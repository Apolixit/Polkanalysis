using Ardalis.GuardClauses;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Common
{
    public class QueryStorage<TKey, TStorage>
        where TKey : IType, new()
        where TStorage : IType, new()
    {
        /// <summary>
        /// Parameter to be send to <see cref="StorageFunctionAsync"/>
        /// </summary>
        public QueryStorageFunction QueryStorageFunction { get; set; }

        /// <summary>
        /// Filters parameters
        /// </summary>
        public QueryFilterFunction QueryFilterFunction { get; set; }

        /// <summary>
        /// Storage function to be called
        /// </summary>
        public Func<QueryStorageFunction, QueryFilterFunction, CancellationToken, Task<List<(TKey, TStorage)>>> StorageFunctionAsync { get; set; }

        public QueryStorage(
            Func<QueryStorageFunction, QueryFilterFunction, CancellationToken, Task<List<(TKey, TStorage)>>> storageFunctionAsync, QueryStorageFunction query) : this(storageFunctionAsync, query, new QueryFilterFunction()) { }

        public QueryStorage(
            Func<QueryStorageFunction, QueryFilterFunction, CancellationToken, Task<List<(TKey, TStorage)>>> storageFunctionAsync, QueryStorageFunction query, QueryFilterFunction filter)
        {
            StorageFunctionAsync = storageFunctionAsync;
            QueryStorageFunction = query;
            QueryFilterFunction = filter;
        }

        public async Task<List<(TKey, TStorage)>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return await StorageFunctionAsync(QueryStorageFunction, QueryFilterFunction, cancellationToken);
        }

        public QueryStorage<TKey, TStorage> Take(int take)
        {
            Guard.Against.NegativeOrZero(take);

            QueryFilterFunction.NbElementTake = take;
            return this;
        }

        public QueryStorage<TKey, TStorage> Skip(int skip)
        {
            Guard.Against.NegativeOrZero(skip);

            QueryFilterFunction.NbElementSkip = skip;
            return this;
        }

        public QueryStorage<TKey, TStorage> ResetFilters()
        {
            QueryFilterFunction.NbElementSkip = null;
            QueryFilterFunction.NbElementTake = null;

            return this;
        }
    }
}
