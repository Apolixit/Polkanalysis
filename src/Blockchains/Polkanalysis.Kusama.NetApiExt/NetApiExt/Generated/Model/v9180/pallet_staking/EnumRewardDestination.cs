//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_staking
{
    public enum RewardDestination
    {
        Staked = 0,
        Stash = 1,
        Controller = 2,
        Account = 3,
        None = 4
    }

    /// <summary>
    /// >> 14820 - Variant[pallet_staking.RewardDestination]
    /// </summary>
    public sealed class EnumRewardDestination : BaseEnumExt<RewardDestination, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, BaseVoid>
    {
    }
}