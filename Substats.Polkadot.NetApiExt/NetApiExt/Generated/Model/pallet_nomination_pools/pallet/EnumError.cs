//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.pallet
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
    /// >> 631 - Variant[pallet_nomination_pools.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnumExt<Error, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.pallet.EnumDefensiveError, BaseVoid, BaseVoid, BaseVoid>
    {
    }
}
