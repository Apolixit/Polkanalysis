using Ajuna.NetApi;
using Substats.Domain.Contracts.Secondary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Common.Repository.Rpc
{
    public class ChainRpc : IChain
    {
        private readonly SubstrateClient _client;

        internal ChainRpc(SubstrateClient client)
        {
            _client = client;
        }
    }
}
