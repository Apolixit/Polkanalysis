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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_nis.pallet
{
    public enum Error
    {
        DurationTooSmall = 0,
        DurationTooBig = 1,
        AmountTooSmall = 2,
        BidTooLow = 3,
        UnknownReceipt = 4,
        NotOwner = 5,
        NotExpired = 6,
        UnknownBid = 7,
        PortionTooBig = 8,
        Unfunded = 9,
        AlreadyFunded = 10,
        Throttled = 11,
        MakesDust = 12,
        AlreadyCommunal = 13,
        AlreadyPrivate = 14
    }

    /// <summary>
    /// >> 2459 - Variant[pallet_nis.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}