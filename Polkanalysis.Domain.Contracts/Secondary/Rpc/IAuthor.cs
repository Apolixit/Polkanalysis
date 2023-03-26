using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Rpc
{
    /// <summary>
    /// Extract from <see cref="Ajuna.NetApi.Modules.Author"/>
    /// </summary>
    //public interface IAuthor
    //{
    //    public Task<Extrinsic[]> PendingExtrinsicAsync(CancellationToken token);
    //    public Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback, Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token);
    //    public Task<string> SubmitAndWatchExtrinsicAsync(Action<string, ExtrinsicStatus> callback, string parameters, CancellationToken token);
    //    public Task<Hash> SubmitExtrinsicAsync(Method method, Account account, ChargeType charge, uint lifeTime, CancellationToken token);
    //    public Task<Hash> SubmitExtrinsicAsync(string parameters, CancellationToken token);
    //    public Task<bool> UnwatchExtrinsicAsync(string subscriptionId, CancellationToken token);
    //}
}
