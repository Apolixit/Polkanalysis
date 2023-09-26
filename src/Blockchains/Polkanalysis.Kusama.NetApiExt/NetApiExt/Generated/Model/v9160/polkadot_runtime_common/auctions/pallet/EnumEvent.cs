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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.polkadot_runtime_common.auctions.pallet
{
    public enum Event
    {
        AuctionStarted = 0,
        AuctionClosed = 1,
        Reserved = 2,
        Unreserved = 3,
        ReserveConfiscated = 4,
        BidAccepted = 5,
        WinningOffset = 6
    }

    /// <summary>
    /// >> 16193 - Variant[polkadot_runtime_common.auctions.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}