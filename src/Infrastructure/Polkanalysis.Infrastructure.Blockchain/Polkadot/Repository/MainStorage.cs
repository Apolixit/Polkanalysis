using Substrate.NetApi.Model.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using System.Runtime.CompilerServices;
using Substrate.NetApi;
using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Helpers;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository
{
    public abstract class MainStorage
    {
        protected readonly SubstrateClientExt _client;
        protected readonly IBlockchainMapping _mapper;
        protected readonly ILogger _logger;

        private string? _blockHash = null;
        public string? BlockHash {
            get
            {
                return _blockHash;
            }
            set
            {
                _blockHash = value;

                // TODO : change it in Toolchain SDK to get blockHash property as interface member
                _client.AuctionsStorage.blockHash = _blockHash;
                _client.AuthorshipStorage.blockHash = _blockHash;
                _client.BabeStorage.blockHash = _blockHash;
                _client.BalancesStorage.blockHash = _blockHash;
                _client.CrowdloanStorage.blockHash = _blockHash;
                _client.IdentityStorage.blockHash = _blockHash;
                _client.NominationPoolsStorage.blockHash = _blockHash;
                _client.ParaSessionInfoStorage.blockHash = _blockHash;
                _client.ParasStorage.blockHash = _blockHash;
                _client.RegistrarStorage.blockHash = _blockHash;
                _client.SessionStorage.blockHash = _blockHash;
                _client.StakingStorage.blockHash = _blockHash;
                _client.SystemStorage.blockHash = _blockHash;
                _client.TimestampStorage.blockHash = _blockHash;
            }
        }

        protected MainStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger)
        {
            _client = client;
            _mapper = mapper;
            _logger = logger;
        }

        protected async Task<uint> GetVersionAsync(CancellationToken token)
        {
            var result = await _client.State.GetRuntimeVersionAtAsync(BlockHash, token);
            return result.SpecVersion;
        }

        protected TDestination? Map<TSource, TDestination>(TSource source, [CallerMemberName] string callerName = "")
            where TSource : IType
            where TDestination : IType, new()
        {
            if (source is null)
            {
                _logger.LogDebug($"Storage version call {callerName} response is null");
                return default;
            }

            _logger.LogDebug($"Storage call {callerName} response is {source}");

            var mapped = _mapper.Map<TSource, TDestination>(source);

            _logger.LogDebug($"Storage call {callerName} mapped response is {mapped}");
            return mapped;
        }

        protected object? Map(object? source, Type sourceType, Type destinationType, [CallerMemberName] string callerName = "")
        {
            if (source is null)
            {
                _logger.LogDebug($"Storage call {callerName} response is null");
                return default;
            }

            _logger.LogDebug($"Storage call {callerName} response is {source}");

            var mapped = _mapper.Map(source, sourceType, destinationType);

            _logger.LogDebug($"Storage call {callerName} mapped response is {mapped}");
            return mapped;
        }

        protected async Task<TDestination?> MapWithVersionAsync<TSource, TDestination>(TSource source, CancellationToken token, [CallerMemberName] string callerName = "")
            where TSource : IType
            where TDestination : IType
        {
            var version = await GetVersionAsync(token);
            if (source is null)
            {
                _logger.LogDebug($"Storage version (= {version}) call {callerName} response is null");
                return default;
            }

            _logger.LogDebug($"Storage version (= {version}) call {callerName} response is {source}");

            var mapped = _mapper.MapWithVersion<TSource, TDestination>(version, source);

            _logger.LogDebug($"Storage version (= {version}) call {callerName} mapped response is {mapped}");
            return mapped;
        }

        

        /// <summary>
        /// Shortcut to build an AccountId32Base (often used as input)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base> MapAccoundId32Async(SubstrateAccount account, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>(version, account);
        }

        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase> MapIdAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase>(version, key);
        }

        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase> MapHashAsync(Hash key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase>(version, key);
        }

        /// <summary>
        /// Call storage with input parameter and return same type as Ajuna SDK
        /// Handle null value by returning empty class
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="funcParams"></param>
        /// <param name="token"></param>
        /// <param name="callerName"></param>
        /// <returns></returns>
        protected async Task<T> GetStorageWithParamsAsync<I, T>(
            I input,
            Func<I, string> funcParams,
            CancellationToken token,
            [CallerMemberName] string callerName = "")
            where I : IType, new()
            where T : IType, new()
        {
            return await GetStorageAsync<T>(funcParams(input), token, callerName) ?? new T();
        }

        /// <summary>
        /// Call storage with input parameter and convert Ajuna SDK to Domain class
        /// Handle null value by returning empty class instance
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="funcParams"></param>
        /// <param name="token"></param>
        /// <param name="callerName"></param>
        /// <returns></returns>
        protected async Task<T> GetStorageWithParamsAsync<I, R, T>(
        I input,
        Func<I, string> funcParams,
        CancellationToken token,
        [CallerMemberName] string callerName = "")
        where I : IType, new()
        where R : IType, new()
        where T : IType, new()
        {
            Guard.Against.Null(input, nameof(input));
            Guard.Against.Null(funcParams, nameof(funcParams));

            var result = await GetStorageAsync<R>(funcParams(input), token, callerName);

            // TODO : manage version !
            var mappedType = new T();
            if (result == null) return mappedType;

            mappedType.Create(result.Encode());
            return mappedType;

            //return PolkadotMapping.Instance.Map<R, T>(result);
        }

        protected async Task<T> GetStorageAsync<T>(
            Func<string> funcParams,
            CancellationToken token,
            [CallerMemberName] string callerName = "")
            where T : IType, new()
        {
            Guard.Against.Null(funcParams, nameof(funcParams));

            return await GetStorageAsync<T>(funcParams(), token, callerName) ?? new T();
        }

        protected async Task<T> GetStorageAsync<R, T>(
        Func<string> funcParams,
        CancellationToken token,
        [CallerMemberName] string callerName = "")
        where R : IType, new()
        where T : IType, new()
        {
            Guard.Against.Null(funcParams, nameof(funcParams));

            var result = await GetStorageAsync<R>(funcParams(), token, callerName);
            var mappedType = new T();
            if (result == null) return mappedType;

            mappedType.Create(result.Encode());
            return mappedType;
            //return PolkadotMapping.Instance.Map<R, T>(result);
        }

        /// <summary>
        /// Just a simple wrapper to <see cref="SubstrateClient.GetStorageAsync"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <param name="blockhash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<T?> GetStorageAsync<T>(
            string parameters,
            CancellationToken token,
            [CallerMemberName] string callerName = "")
            where T : IType, new()
        {
            _logger.LogTrace($"Storage call from {callerName} with parameters = {parameters}");
            var res = await _client.GetStorageAsync<T>(parameters, BlockHash, token);

            if (res == null)
            {
                _logger.LogTrace($"Storage call response is null");
            }

            _logger.LogTrace($"Storage call response is {res}");
            return res;
        }

        public async Task SubscribeToAsync<T>(string storageParam, Action<T> callback, CancellationToken cancellationToken)
            where T : IType, new()
        {
            _ = await _client.SubscribeStorageKeyAsync(storageParam,
                (subscriptionId, storageChangeSet) =>
            {
                if (storageChangeSet.Changes == null
                    || storageChangeSet.Changes.Length == 0
                    || storageChangeSet.Changes[0].Length < 2)
                {
                    throw new InvalidOperationException("Couldn't update account information. Please check 'CallBackAccountChange'");
                }

                var hexString = storageChangeSet.Changes[0][1];

                // No data
                if (string.IsNullOrEmpty(hexString)) return;

                var elem = new T();
                elem.Create(hexString);

                callback(elem);
            }, cancellationToken);
        }

        protected async Task<List<(TKey, TStorage)>> GetAllStorageAsync<TKey, TStorage>(
            QueryStorageFunction query, QueryFilterFunction filter, CancellationToken token)
            where TKey : IType, new()
            where TStorage : IType, new()
        {
            Guard.Against.NullOrEmpty(query.ModuleName);
            Guard.Against.NullOrEmpty(query.MethodName);
            Guard.Against.NullOrEmpty(query.StorageParam);

            byte[]? startKey = null;
            int defaultPagination = 1000;

            filter.NbElementSkip = filter.NbElementSkip ?? 0;

            uint pageLength = (uint)Math.Min(defaultPagination, filter.NbElementTake.GetValueOrDefault(defaultPagination) + filter.NbElementSkip.Value);

            var storageId = Utils.HexToByteArray(query.StorageParam);

            List<(byte[], IType, IType)> allPages = new();
            bool fetch = true;
            while (fetch)
            {
                var storageKeys = await _client.State.GetKeysPagedAsync(storageId, pageLength, startKey, token);

                if (storageKeys == null || !storageKeys.Any())
                    break;

                if (storageKeys.Count() <= filter.NbElementSkip)
                {
                    filter.NbElementSkip -= storageKeys.Count();
                    startKey = Utils.HexToByteArray(storageKeys.Last().ToString());

                    continue;
                }

                var storageElement = storageKeys.Skip(filter.NbElementSkip.Value).Take(filter.NbElementTake.GetValueOrDefault((int)pageLength));
                filter.NbElementSkip = 0;

                var page = await GetAllStoragePagedAsync(query.ModuleName, query.MethodName, query.SourceKeyType, query.StorageKeyType, storageElement, storageId, pageLength, token, query.KeyParamSize);

                if (page == null || page.Count == 0)
                    break;

                allPages.AddRange(page);
                startKey = page.Last().Item1;

                if (filter.NbElementTake != null && allPages.Count >= filter.NbElementTake.Value) fetch = false;
            }

            var mapped = allPages
                .Select(x =>
                {
                    TKey mappedKey = _mapper.Map<TKey>(x.Item2);
                    TStorage mappedStorage = _mapper.Map<TStorage>(x.Item3);
                    return (mappedKey, mappedStorage);
                })
                .ToList();

            return mapped;
        }


        protected async Task<List<(byte[], IType, IType)>> GetAllStoragePagedAsync(
            string module, string item, Type keySource, Type storageSource, IEnumerable<JToken> storageKeys, byte[] storageId, uint page, CancellationToken token, int paramSize = 0)
        {
            if (page < 2 || page > 1000)
            {
                throw new NotSupportedException("Page size must be in the range of 2 - 1000");
            }

            var result = new List<(byte[], IType, IType)>();

            var storageChangeSets = await _client.State.GetQueryStorageAtAsync(
                storageKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), BlockHash, token);

            if (storageChangeSets != null)
            {
                foreach (var storageChangeSet in storageChangeSets.First().Changes)
                {
                    var storageKeyString = storageChangeSet[0];

                    var keyParam = DynamicInstance.CreateInstance<IType>(keySource);
                    var paramTypeSize = keyParam.TypeSize > 0 ? keyParam.TypeSize : paramSize;
                    keyParam.Create(storageKeyString[^(paramTypeSize * 2)..]);

                    var valueParam = DynamicInstance.CreateInstance<IType>(storageSource);
                    valueParam.Create(storageChangeSet[1]);

                    result.Add((Utils.HexToByteArray(storageKeyString), keyParam, valueParam));
                }
            }

            return result;
        }
    }
}
