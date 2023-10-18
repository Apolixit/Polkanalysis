using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    public enum ClaimPermission
    {
        Permissioned = 0,
        PermissionlessCompound = 1,
        PermissionlessWithdraw = 2,
        PermissionlessAll = 3
    }

    /// <summary>
    /// >> 14199 - Variant[pallet_nomination_pools.ClaimPermission]
    /// </summary>
    public sealed class EnumClaimPermission : BaseEnum<ClaimPermission>
    {
    }
}
