using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    [DomainMapping("pallet_nomination_pools")]
    public enum ConfigOp
    {

        Noop = 0,

        Set = 1,

        Remove = 2,
    }

    /// <summary>
    /// >> 373 - Variant[pallet_nomination_pools.ConfigOp]
    /// </summary>
    public sealed class EnumConfigOp : BaseEnumExt<ConfigOp, BaseVoid, SubstrateAccount, BaseVoid>
    {
    }
}
