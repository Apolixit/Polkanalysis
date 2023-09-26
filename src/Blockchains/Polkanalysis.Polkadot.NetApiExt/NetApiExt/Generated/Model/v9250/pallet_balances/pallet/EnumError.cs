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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_balances.pallet
{
    public enum Error
    {
        VestingBalance = 0,
        LiquidityRestrictions = 1,
        InsufficientBalance = 2,
        ExistentialDeposit = 3,
        KeepAlive = 4,
        ExistingVestingSchedule = 5,
        DeadAccount = 6,
        TooManyReserves = 7
    }

    /// <summary>
    /// >> 7117 - Variant[pallet_balances.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}