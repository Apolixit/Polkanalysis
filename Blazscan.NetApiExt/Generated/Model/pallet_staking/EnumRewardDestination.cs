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


namespace Blazscan.NetApiExt.Generated.Model.pallet_staking
{
    
    
    public enum RewardDestination
    {
        
        Staked = 0,
        
        Stash = 1,
        
        Controller = 2,
        
        Account = 3,
        
        None = 4,
    }
    
    /// <summary>
    /// >> 205 - Variant[pallet_staking.RewardDestination]
    /// </summary>
    public sealed class EnumRewardDestination : BaseEnumExt<RewardDestination, BaseVoid, BaseVoid, BaseVoid, Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseVoid>
    {
    }
}
