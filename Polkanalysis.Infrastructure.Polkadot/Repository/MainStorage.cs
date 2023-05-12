using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary;
using Substrate.NetApi;
using Ardalis.GuardClauses;

namespace Polkanalysis.Infrastructure.Polkadot.Repository
{
    public abstract class MainStorage
    {
        protected readonly SubstrateClientExt _client;
        protected readonly ILogger _logger;
        public string? BlockHash { get; set; } = null;

        protected MainStorage(SubstrateClientExt client, ILogger logger)
        {
            _client = client;
            _logger = logger;
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
            Guard.Against.Null(input);
            Guard.Against.Null(funcParams);
            
            var result = await GetStorageAsync<R>(funcParams(input), token, callerName);

            if (result == null) return new T();

            return PolkadotMapping.Instance.Map<R, T>(result);
        }

        protected async Task<T> GetStorageAsync<T>(
            Func<string> funcParams,
            CancellationToken token,
            [CallerMemberName] string callerName = "")
            where T : IType, new()
        {
            Guard.Against.Null(funcParams);

            return await GetStorageAsync<T>(funcParams(), token, callerName) ?? new T();
        }

        protected async Task<T> GetStorageAsync<R, T>(
        Func<string> funcParams,
        CancellationToken token,
        [CallerMemberName] string callerName = "")
        where R : IType, new()
        where T : IType, new()
        {
            Guard.Against.Null(funcParams);

            var result = await GetStorageAsync<R>(funcParams(), token, callerName);

            if (result == null) return new T();

            return PolkadotMapping.Instance.Map<R, T>(result);
        }

        /// <summary>
        /// Just a simple wrapper to <see cref="Substrate.NetApi.SubstrateClient.GetStorageAsync"/>
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

        protected async Task<List<(TKey, TStorage)>> GetAllStorageAsync<TKeySource, TKey, TStorageSource, TStorage>(string module, string item, CancellationToken token)
            where TKey : IType, new()
            where TKeySource : IType, new()
            where TStorage : IType, new()
            where TStorageSource : IType, new()
        {
            Guard.Against.NullOrEmpty(module);
            Guard.Against.NullOrEmpty(item);

            byte[]? startKey = null;

            List<(byte[], TKeySource, TStorageSource)> allPages = new();

            while (true)
            {
                var page = await GetAllStoragePagedAsync<TKeySource, TStorageSource>(module, item, startKey, 1000, token);
                if (page == null || page.Count == 0)
                {
                    break;
                }

                allPages.AddRange(page);
                startKey = page.Last().Item1;
            }

            //return allPages.Select(x => (x.Item2, x.Item3)).ToList();
            var mapped = allPages
                .Select(x => (PolkadotMapping.Instance.Map<TKeySource, TKey>(x.Item2), PolkadotMapping.Instance.Map<TStorageSource, TStorage>(x.Item3)))
                .ToList();

            return mapped;
        }

        protected async Task<List<(byte[], T1, T2)>> GetAllStoragePagedAsync<T1, T2>(
            string module, string item, byte[]? startKey, uint page, CancellationToken token)
            where T1 : IType, new()
            where T2 : IType, new()
        {
            if (page < 2 || page > 1000)
            {
                throw new NotSupportedException("Page size must be in the range of 2 - 1000");
            }

            var result = new List<(byte[], T1, T2)>();
            var keyBytes = RequestGenerator.GetStorageKeyBytesHash(module, item);

            var storageKeys = await _client.State.GetKeysPagedAsync(keyBytes, page, startKey, token);

            if (storageKeys == null || !storageKeys.Any())
                return result;

            var storageChangeSets = await _client.State.GetQueryStorageAtAsync(
                storageKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), BlockHash, token);

            if (storageChangeSets != null)
            {
                foreach (var storageChangeSet in storageChangeSets.First().Changes)
                {
                    var storageKeyString = storageChangeSet[0];

                    var keyParam = new T1();
                    keyParam.Create(storageKeyString[^(keyBytes.Length * 2)..]);

                    var valueParam = new T2();
                    valueParam.Create(storageChangeSet[1]);

                    result.Add((Utils.HexToByteArray(storageKeyString), keyParam, valueParam));
                }
            }

            return result;
        }
    }
}
