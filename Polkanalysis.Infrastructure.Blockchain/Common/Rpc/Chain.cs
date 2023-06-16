using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Secondary.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Common.Rpc
{
    //public class Chain : IChain
    //{
    //    public Task<BlockData> GetBlockAsync(Hash hash, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Hash> GetBlockHashAsync(BlockNumber blockNumber, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Hash> GetFinalizedHeadAsync(CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Header> GetHeaderAsync(Hash hash, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> UnsubscribeNewHeadsAsync(string subscriptionId, CancellationToken token)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
