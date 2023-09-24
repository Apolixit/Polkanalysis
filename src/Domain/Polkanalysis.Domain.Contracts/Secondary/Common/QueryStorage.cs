using Ardalis.GuardClauses;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common
{
    public class QueryStorage<TKey, TStorage>
        where TKey : IType, new()
        where TStorage : IType, new()
    {
        public const int DefaultPagination = 100;

        public int? NbTake { get; internal set; } = null;
        public int? NbSkip { get; internal set; } = null;
        public int Pagination { get; internal set; } = DefaultPagination;

        public Func<string, string, CancellationToken, int?, int?, Task<List<(TKey, TStorage)>>> StorageFunctionAsync { get; set; }
        public Func<string, string, string, CancellationToken, int?, int?, int?, Task<List<(TKey, TStorage)>>> StorageFunctionAsyncFull { get; set; }
        public string ModuleName { get; init; }
        public string ItemName { get; init; }

        public string StorageParam { get; init; }
        public int KeyParamSize { get; init; }

        public QueryStorage(Func<string, string, string, CancellationToken, int?, int?, int?, Task<List<(TKey, TStorage)>>> storageFunctionAsync, string module, string item, string storageParam, int keyParamSize)
        {
            StorageFunctionAsyncFull = storageFunctionAsync;
            StorageParam = storageParam;
            KeyParamSize = keyParamSize;

            ModuleName = module;
            ItemName = item;
        }
        public QueryStorage(Func<string, string, CancellationToken, int?, int?, Task<List<(TKey, TStorage)>>> storageFunctionAsync, string module, string item)
        {
            ModuleName = module;
            ItemName = item;

            StorageFunctionAsync = storageFunctionAsync;
        }

        public async Task<List<(TKey, TStorage)>> ExecuteAsync(CancellationToken cancellationToken)
        {
            if(!string.IsNullOrEmpty(StorageParam))
            {
                return await StorageFunctionAsyncFull(ModuleName, ItemName, StorageParam, cancellationToken, NbTake, NbSkip, KeyParamSize);
            } else
            {
                return await StorageFunctionAsync(ModuleName, ItemName, cancellationToken, NbTake, NbSkip);
            }
        }

        public QueryStorage<TKey, TStorage> Take(int take)
        {
            Guard.Against.NegativeOrZero(take);

            NbTake = take;
            return this;
        }

        public QueryStorage<TKey, TStorage> Skip(int skip)
        {
            Guard.Against.NegativeOrZero(skip);

            NbSkip = skip;
            return this;
        }

        public QueryStorage<TKey, TStorage> ResetFilters()
        {
            NbSkip = null;
            NbTake = null;

            return this;
        }
    }
}
