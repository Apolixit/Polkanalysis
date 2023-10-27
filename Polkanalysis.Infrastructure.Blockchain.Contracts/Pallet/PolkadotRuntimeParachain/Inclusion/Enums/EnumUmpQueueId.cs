using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums
{
    public enum UmpQueueId
    {
        Para = 0
    }

    /// <summary>
    /// >> 15155 - Variant[polkadot_runtime_parachains.inclusion.UmpQueueId]
    /// </summary>
    public sealed class EnumUmpQueueId : BaseEnumExt<UmpQueueId, Id>
    {
    }
}
