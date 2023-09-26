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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_recovery.pallet
{
    public enum Error
    {
        NotAllowed = 0,
        ZeroThreshold = 1,
        NotEnoughFriends = 2,
        MaxFriends = 3,
        NotSorted = 4,
        NotRecoverable = 5,
        AlreadyRecoverable = 6,
        AlreadyStarted = 7,
        NotStarted = 8,
        NotFriend = 9,
        DelayPeriod = 10,
        AlreadyVouched = 11,
        Threshold = 12,
        StillActive = 13,
        AlreadyProxy = 14,
        BadState = 15
    }

    /// <summary>
    /// >> 664 - Variant[pallet_recovery.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}