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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.pallet_nomination_pools.pallet
{
    public enum DefensiveError
    {
        NotEnoughSpaceInUnbondPool = 0,
        PoolNotFound = 1,
        RewardPoolNotFound = 2,
        SubPoolsNotFound = 3,
        BondedStashKilledPrematurely = 4
    }

    /// <summary>
    /// >> 7557 - Variant[pallet_nomination_pools.pallet.DefensiveError]
    /// </summary>
    public sealed class EnumDefensiveError : BaseEnum<DefensiveError>
    {
    }
}