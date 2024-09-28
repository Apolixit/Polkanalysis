using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums
{
    [DomainMapping("polkadot_runtime_parachains/inclusion")]
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
