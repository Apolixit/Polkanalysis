using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools.Enums
{
    public enum Error
    {

        PoolNotFound = 0,

        PoolMemberNotFound = 1,

        RewardPoolNotFound = 2,

        SubPoolsNotFound = 3,

        AccountBelongsToOtherPool = 4,

        FullyUnbonding = 5,

        MaxUnbondingLimit = 6,

        CannotWithdrawAny = 7,

        MinimumBondNotMet = 8,

        OverflowRisk = 9,

        NotDestroying = 10,

        NotNominator = 11,

        NotKickerOrDestroying = 12,

        NotOpen = 13,

        MaxPools = 14,

        MaxPoolMembers = 15,

        CanNotChangeState = 16,

        DoesNotHavePermission = 17,

        MetadataExceedsMaxLen = 18,

        Defensive = 19,

        PartialUnbondNotAllowedPermissionlessly = 20,

        PoolIdInUse = 21,

        InvalidPoolId = 22,
    }

    /// <summary>
    /// >> 632 - Variant[pallet_nomination_pools.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnumExt<Error, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, EnumDefensiveError, BaseVoid, BaseVoid, BaseVoid>
    {
    }
}
