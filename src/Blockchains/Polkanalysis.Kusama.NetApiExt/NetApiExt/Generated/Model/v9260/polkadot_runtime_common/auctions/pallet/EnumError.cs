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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.polkadot_runtime_common.auctions.pallet
{
    public enum Error
    {
        AuctionInProgress = 0,
        LeasePeriodInPast = 1,
        ParaNotRegistered = 2,
        NotCurrentAuction = 3,
        NotAuction = 4,
        AuctionEnded = 5,
        AlreadyLeasedOut = 6
    }

    /// <summary>
    /// >> 10749 - Variant[polkadot_runtime_common.auctions.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}