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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_gilt.pallet
{
    public enum Error
    {
        DurationTooSmall = 0,
        DurationTooBig = 1,
        AmountTooSmall = 2,
        BidTooLow = 3,
        Unknown = 4,
        NotOwner = 5,
        NotExpired = 6,
        NotFound = 7
    }

    /// <summary>
    /// >> 15240 - Variant[pallet_gilt.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}