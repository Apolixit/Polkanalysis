using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Common
{
    public interface IDelegateSystemChain
    {
        Task<uint> CurrentBlockForSystemChainAsync(SubstrateClient systemChainClient, string systemChainName, string sourceChainBlockHash, CancellationToken token);
        Task<Hash> GetAssociatedHashFromOtherChainAsync(SubstrateClient systemChainClient, string systemChainName, uint blockNumber, CancellationToken token);
    }
}
