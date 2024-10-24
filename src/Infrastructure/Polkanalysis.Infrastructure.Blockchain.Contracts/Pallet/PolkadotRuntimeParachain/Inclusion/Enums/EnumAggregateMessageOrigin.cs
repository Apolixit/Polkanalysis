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
    public enum AggregateMessageOrigin
    {
        Ump = 0
    }

    /// <summary>
    /// >> 15154 - Variant[polkadot_runtime_parachains.inclusion.AggregateMessageOrigin]
    /// </summary>
    public sealed class EnumAggregateMessageOrigin : BaseEnumExt<AggregateMessageOrigin, EnumUmpQueueId>
    {
    }
}
