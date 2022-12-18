using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.NetApiExt.Generated;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Repository
{
    public class SubstrateNodeRepositoryDirectAccess : ISubstrateNodeRepository
    {
        private readonly Uri _nodeUri;
        private SubstrateClientExt? _client;

        public SubstrateNodeRepositoryDirectAccess(IConfiguration configuration)
        {
            _nodeUri = new Uri(configuration["defaultEndpoint"]);
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
    }
}
