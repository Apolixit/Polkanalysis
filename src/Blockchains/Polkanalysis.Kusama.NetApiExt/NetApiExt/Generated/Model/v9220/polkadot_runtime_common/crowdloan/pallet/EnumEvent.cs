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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_runtime_common.crowdloan.pallet
{
    public enum Event
    {
        Created = 0,
        Contributed = 1,
        Withdrew = 2,
        PartiallyRefunded = 3,
        AllRefunded = 4,
        Dissolved = 5,
        HandleBidResult = 6,
        Edited = 7,
        MemoUpdated = 8,
        AddedToNewRaise = 9
    }

    /// <summary>
    /// >> 12447 - Variant[polkadot_runtime_common.crowdloan.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.EnumResult>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id>
    {
    }
}