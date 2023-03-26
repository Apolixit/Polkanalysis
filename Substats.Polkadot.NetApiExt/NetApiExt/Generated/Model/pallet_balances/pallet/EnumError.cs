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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet
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
        
        TooManyReserves = 7,
    }
    
    /// <summary>
    /// >> 480 - Variant[pallet_balances.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
