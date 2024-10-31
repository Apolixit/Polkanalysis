using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Helpers;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Common
{
    public abstract class AbstractStorage
    {
        private readonly SubstrateClient _client;
        protected readonly IBlockchainMapping _mapper;
        protected readonly ILogger _logger;

        public abstract string? BlockHash { get; set; }

        protected AbstractStorage(SubstrateClient client, IBlockchainMapping mapper, ILogger logger)
        {
            _client = client;
            _mapper = mapper;
            _logger = logger;
        }

        protected async Task<uint> GetVersionAsync(CancellationToken token)
        {
            var result = await _client.State.GetRuntimeVersionAsync(BlockHash, token);
            return result.SpecVersion;
        }

        protected TDestination? Map<TSource, TDestination>(TSource source, [CallerMemberName] string callerName = "")
            where TSource : IType
            where TDestination : IType, new()
        {
            if (source is null)
            {
                _logger.LogDebug("Storage version call {callerName} response is null", callerName);
                return default;
            }

            _logger.LogDebug("Storage call {callerName} response is {source}", callerName, source);

            var mapped = _mapper.Map<TSource, TDestination>(source);

            _logger.LogDebug("Storage call {callerName} mapped response is {mapped}", callerName, mapped);
            return mapped;
        }

        /// <summary>
        /// Maps the source object to the destination object with the specified version.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TDestination">The type of the destination object.</typeparam>
        /// <param name="source">The source object to map.</param>
        /// <param name="token">The cancellation token.</param>
        /// <param name="callerName">The name of the calling member.</param>
        /// <returns>The mapped destination object.</returns>
        protected async Task<TDestination?> MapWithVersionAsync<TSource, TDestination>(TSource source, CancellationToken token, [CallerMemberName] string callerName = "")
            where TSource : IType
            where TDestination : IType
        {
            var version = await GetVersionAsync(token);
            if (source is null)
            {
                _logger.LogDebug("Storage version (= {version}) call {callerName} response is null", version, callerName);
                return default;
            }

            _logger.LogDebug("Storage version (= {version}) call {callerName} response is {source}", version, callerName, source);

            var mapped = _mapper.MapWithVersion<TSource, TDestination>(version, source);

            _logger.LogDebug("Storage version (= {version}) call {callerName} mapped response is {mapped}", version, callerName, mapped);
            return mapped;
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
            _logger.LogTrace("Storage call from {callerName} with parameters = {parameters}", callerName, parameters);
            var res = await _client.GetStorageAsync<T>(parameters, BlockHash, token);

            if (res is null)
            {
                _logger.LogTrace($"Storage call response is null");
            }

            _logger.LogTrace("Storage call response is {res}", res);
            return res;
        }

        /// <summary>
        /// Subscribe to a new storage key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storageParam"></param>
        /// <param name="callback"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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

                string debug = $"[MainStorage] {nameof(GetAllStorageAsync)} StorageKeys : storageId = {Utils.Bytes2HexString(storageId)} | pageLength = {pageLength} | startKey = {(startKey is not null ? Utils.Bytes2HexString(startKey) : " - ")} {string.Join("\n", storageKeys.Select(x => x.ToString()))}";
                _logger.LogDebug(debug);

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
            var storageKeyStrings = storageKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList();

            var debug = $"[MainStorage] {nameof(GetAllStoragePagedAsync)}\n\t module = {module}\n\t item = {item}\n\t keySource = {keySource}\n\t storageSource = {storageSource}\n\t storageId = {Utils.Bytes2HexString(storageId)}\n\t page = {page}\n\t BlockHash = {BlockHash}\n" +
                $"{string.Join("\n", storageKeyStrings.Select(x => Utils.Bytes2HexString(x)))}";
            _logger.LogDebug(debug);

            var storageChangeSets = await _client.State.GetQueryStorageAtAsync(storageKeyStrings, BlockHash, token);

            if (storageChangeSets != null)
            {
                var debug2 = $"{string.Join(", ", storageChangeSets.First().Changes.SelectMany(x => x))}";
                _logger.LogDebug(debug2);

                foreach (var storageChangeSet in storageChangeSets.First().Changes)
                {
                    try
                    {
                        var storageKeyString = storageChangeSet[0];

                        var keyParam = DynamicInstance.CreateInstance<IType>(keySource);
                        var paramTypeSize = keyParam.TypeSize > 0 ? keyParam.TypeSize : paramSize;
                        keyParam.Create(storageKeyString[^(paramTypeSize * 2)..]);

                        var valueParam = DynamicInstance.CreateInstance<IType>(storageSource);
                        valueParam.Create(storageChangeSet[1]);

                        result.Add((Utils.HexToByteArray(storageKeyString), keyParam, valueParam));
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex,
                                         $"[{nameof(GetAllStoragePagedAsync)}] Error while processing storage change set. " +
                                         $"Loop index = {storageChangeSets.First().Changes.ToList().IndexOf(storageChangeSet)} | " +
                                         $"storageChangeSet[0] = {storageChangeSet[0]} | " +
                                         $"storageChangeSet[1] = {storageChangeSet[1]}");
                        throw;
                    }
                }
            }

            return result;
        }
    }
}
