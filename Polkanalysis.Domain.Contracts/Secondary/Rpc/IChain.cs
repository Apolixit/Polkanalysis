using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Rpc
{
    /// <summary>
    /// Extract from <see cref="Ajuna.NetApi.Modules.Chain"/>
    /// </summary>
    //public interface IChain
    //{
    //    Task<BlockData> GetBlockAsync(Hash hash, CancellationToken token);
    //    Task<Hash> GetBlockHashAsync(BlockNumber blockNumber, CancellationToken token);
    //    Task<Hash> GetFinalizedHeadAsync(CancellationToken token);
    //    Task<Header> GetHeaderAsync(Hash hash, CancellationToken token);
    //    Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback, CancellationToken token);
    //    Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback, CancellationToken token);
    //    Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback, CancellationToken token);
    //    Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId, CancellationToken token);
    //    Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId, CancellationToken token);
    //    Task<bool> UnsubscribeNewHeadsAsync(string subscriptionId, CancellationToken token);
    //}
}
