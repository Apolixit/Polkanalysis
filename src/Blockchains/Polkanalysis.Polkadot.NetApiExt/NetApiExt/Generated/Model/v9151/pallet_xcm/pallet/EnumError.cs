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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.pallet_xcm.pallet
{
    public enum Error
    {
        Unreachable = 0,
        SendFailure = 1,
        Filtered = 2,
        UnweighableMessage = 3,
        DestinationNotInvertible = 4,
        Empty = 5,
        CannotReanchor = 6,
        TooManyAssets = 7,
        InvalidOrigin = 8,
        BadVersion = 9,
        BadLocation = 10,
        NoSubscription = 11,
        AlreadySubscribed = 12
    }

    /// <summary>
    /// >> 2479 - Variant[pallet_xcm.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}