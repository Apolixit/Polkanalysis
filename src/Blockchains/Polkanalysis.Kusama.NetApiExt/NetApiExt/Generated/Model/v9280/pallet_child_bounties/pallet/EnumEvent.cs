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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.pallet_child_bounties.pallet
{
    public enum Event
    {
        Added = 0,
        Awarded = 1,
        Claimed = 2,
        Canceled = 3
    }

    /// <summary>
    /// >> 8526 - Variant[pallet_child_bounties.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.sp_core.crypto.AccountId32>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.sp_core.crypto.AccountId32>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}