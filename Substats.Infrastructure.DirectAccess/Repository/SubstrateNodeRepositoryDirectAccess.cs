using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class SubstrateNodeRepositoryDirectAccess : ISubstrateNodeRepository
    {
        private readonly Uri _nodeUri;
        private SubstrateClientExt? _client;

        public SubstrateNodeRepositoryDirectAccess(IConfiguration configuration)
        {
            var endpoint = "wss://rpc.polkadot.io"; //configuration["endpoint:current"];
            if (endpoint == null)
                throw new ArgumentNullException($"{nameof(endpoint)} configuration is not set");
            _nodeUri = new Uri(endpoint);
        }

        public SubstrateClientExt Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new SubstrateClientExt(_nodeUri, ChargeTransactionPayment.Default());
                }
                return _client;
            }
        }
        public async Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {

                    isConnectedCallback(Client.IsConnected);
                    if (!Client.IsConnected)
                    {
                        try
                        {
                            await Client.ConnectAsync(cancellationToken);
                        }
                        catch (Exception ex)
                        {
                            // TODO
                            isConnectedCallback(Client.IsConnected);
                        }
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(millisecondCheck), cancellationToken);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {

            }
        }

        //public async Task<T> GetStorageAsync<T>(string parameters, Hash? blockHash, CancellationToken token) where T : IType, new()
        //{
        //    var paramArgs = new List<object> { parameters };
        //    if(blockHash != null)
        //    {
        //        paramArgs.Add(blockHash.Value);
        //    }
        //    string text = await Client.InvokeAsync<string>("state_getStorage", paramArgs.ToArray(), token);
        //    T result = new T();
        //    if (text != null && text.Length > 0)
        //    {
        //        result.Create(text);
        //    }

        //    return result;
        //}
    }
}
