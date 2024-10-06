using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    public enum CommissionClaimPermission
    {
        Permissionless = 0,
        Account = 1
    }

    /// <summary>
    /// >> 19134 - Variant[pallet_nomination_pools.CommissionClaimPermission]
    /// </summary>
    public sealed class EnumCommissionClaimPermission : BaseEnumExt<CommissionClaimPermission, BaseVoid, SubstrateAccount>
    {
    }
}
