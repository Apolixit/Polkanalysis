using Ajuna.NetApi.Model.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository
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
            if(input == null) throw new ArgumentNullException("input");
            
            var result = await GetStorageAsync<R>(funcParams(input), token, callerName);

            if (result == null) return new T();

            return SubstrateMapper.Instance.Map<R, T>(result);
        }

        protected async Task<T> GetStorageAsync<T>(
            Func<string> funcParams,
            CancellationToken token,
            [CallerMemberName] string callerName = "")
            where T : IType, new()
        {
            return await GetStorageAsync<T>(funcParams(), token, callerName) ?? new T();
        }

        protected async Task<T> GetStorageAsync<R, T>(
        Func<string> funcParams,
        CancellationToken token,
        [CallerMemberName] string callerName = "")
        where R : IType, new()
        where T : IType, new()
        {
            var result = await GetStorageAsync<R>(funcParams(), token, callerName);

            if (result == null) return new T();

            return SubstrateMapper.Instance.Map<R, T>(result);
        }

        /// <summary>
        /// Just a simple wrapper to <see cref="Ajuna.NetApi.SubstrateClient.GetStorageAsync"/>
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
    }
}
