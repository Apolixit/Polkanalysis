using Ajuna.NetApi.Model.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
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
        /// Just a simple wrapper to <see cref="Ajuna.NetApi.SubstrateClient.GetStorageAsync"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <param name="blockhash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected async Task<T?> GetStorageAsync<T>(
            string parameters, 
            CancellationToken token, 
            [CallerMemberName] string callerName = "") 
            where T : IType, new()
        {
            _logger.LogTrace($"Storage call from {callerName} with parameters = {parameters}");
            var res = await _client.GetStorageAsync<T>(parameters, BlockHash, token);
            
            if(res == null)
            {
                _logger.LogTrace($"Storage call response is null");
            }

            _logger.LogTrace($"Storage call response is {res}");
            return res;
        }
    }
}
