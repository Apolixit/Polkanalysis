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
    public class PolkadotNodeRepository : ISubstrateNodeRepository
    {
        private readonly ISubstrateClientRepository _substrateClientRepository;

        public PolkadotNodeRepository(ISubstrateClientRepository substrateClientRepository)
        {
            _substrateClientRepository = substrateClientRepository;
        }

        public ISubstrateClientRepository Client => _substrateClientRepository;

        public async Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {

                    isConnectedCallback(Client.Core.IsConnected);
                    if (!Client.Core.IsConnected)
                    {
                        try
                        {
                            await Client.Core.ConnectAsync(cancellationToken);
                        }
                        catch (Exception ex)
                        {
                            // TODO
                            isConnectedCallback(Client.Core.IsConnected);
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
