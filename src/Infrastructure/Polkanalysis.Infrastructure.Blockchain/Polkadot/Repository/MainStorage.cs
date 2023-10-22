using Substrate.NetApi.Model.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using System.Runtime.CompilerServices;
using Substrate.NetApi;
using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using System;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

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

        protected TDestination Map<TSource, TDestination>(TSource source)
            where TSource : IType
            where TDestination : IType
        {
            var mapped = _mapper.Map<TSource, TDestination>(source);
            return mapped;
        }

        protected async Task<TDestination> MapWithVersionAsync<TSource, TDestination>(TSource source, CancellationToken token)
            where TSource : IType
            where TDestination : IType
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<TSource, TDestination>(version, source, token);
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
                SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>(version, account, token);
        }

        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase> MapIdAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase>(version, key, token);
        }

        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase> MapHashAsync(Hash key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase>(version, key, token);
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

        protected Task<List<(TKey, TStorage)>> GetAllStorageAsync<TKeySource, TKey, TStorageSource, TStorage>(
            string module, string item, CancellationToken token, int? nbTake = null, int? nbSkip = null)
            where TKey : IType, new()
            where TKeySource : IType, new()
            where TStorage : IType, new()
            where TStorageSource : IType, new()
            => GetAllStorageAsync<TKeySource, TKey, TStorageSource, TStorage>(module, item, Utils.Bytes2HexString(RequestGenerator.GetStorageKeyBytesHash(module, item)), token, nbTake, nbSkip);

        protected async Task<List<(TKey, TStorage)>> GetAllStorageAsync<TKeySource, TKey, TStorageSource, TStorage>(
            string module, string item, string storageParam, CancellationToken token, int? nbTake = null, int? nbSkip = null, int? paramSize = 0)
            where TKey : IType, new()
            where TKeySource : IType, new()
            where TStorage : IType, new()
            where TStorageSource : IType, new()
        {
            Guard.Against.NullOrEmpty(module, nameof(module));
            Guard.Against.NullOrEmpty(item, nameof(item));

            byte[]? startKey = null;
            int defaultPagination = 1000;

            nbSkip = nbSkip ?? 0;
            //nbTake = nbTake ?? defaultPagination;

            uint pageLength = (uint)Math.Min(defaultPagination, nbTake.GetValueOrDefault(defaultPagination) + nbSkip.Value);

            var storageId = Utils.HexToByteArray(storageParam);

            List<(byte[], TKeySource, TStorageSource)> allPages = new();
            bool fetch = true;
            while (fetch)
            {
                var storageKeys = await _client.State.GetKeysPagedAsync(storageId, pageLength, startKey, token);

                if (storageKeys == null || !storageKeys.Any())
                    break;

                if (storageId.Count() <= nbSkip)
                {
                    nbSkip -= storageId.Count();
                    startKey = Utils.HexToByteArray(storageKeys.Last().ToString());

                    continue;
                    //_logger.LogWarning($"{nameof(nbSkip)} > storageKeys.Count, no data selected");
                    //break;
                }

                var storageElement = storageKeys.Skip(nbSkip.Value).Take(nbTake.GetValueOrDefault((int)pageLength));
                nbSkip = 0;

                var page = await GetAllStoragePagedAsync<TKeySource, TStorageSource>(module, item, storageElement, storageId, pageLength, token, paramSize.Value);

                if (page == null || page.Count == 0)
                    break;

                allPages.AddRange(page);
                startKey = page.Last().Item1;

                if (nbTake != null && allPages.Count >= nbTake.Value) fetch = false;
            }

            var mapped = allPages
                .Select(x =>
                {
                    TKey mappedKey = new();
                    mappedKey.Create(x.Item2.Encode());

                    TStorage mappedStorage = new();
                    mappedStorage.Create(x.Item3.Encode());

                    return (mappedKey, mappedStorage);
                })
                .ToList();

            return mapped;
        }


        protected async Task<List<(byte[], T1, T2)>> GetAllStoragePagedAsync<T1, T2>(
            string module, string item, IEnumerable<JToken> storageKeys, byte[] storageId, uint page, CancellationToken token, int paramSize = 0)
            where T1 : IType, new()
            where T2 : IType, new()
        {
            if (page < 2 || page > 1000)
            {
                throw new NotSupportedException("Page size must be in the range of 2 - 1000");
            }

            var result = new List<(byte[], T1, T2)>();

            var storageChangeSets = await _client.State.GetQueryStorageAtAsync(
                storageKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), BlockHash, token);

            if (storageChangeSets != null)
            {
                foreach (var storageChangeSet in storageChangeSets.First().Changes)
                {
                    var storageKeyString = storageChangeSet[0];

                    var keyParam = new T1();
                    var paramTypeSize = keyParam.TypeSize > 0 ? keyParam.TypeSize : paramSize;
                    keyParam.Create(storageKeyString[^(paramTypeSize * 2)..]);

                    var valueParam = new T2();
                    valueParam.Create(storageChangeSet[1]);

                    result.Add((Utils.HexToByteArray(storageKeyString), keyParam, valueParam));
                }
            }

            return result;
        }
    }
}
