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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.pallet_tips.pallet
{
    public enum Event
    {
        NewTip = 0,
        TipClosing = 1,
        TipClosed = 2,
        TipRetracted = 3,
        TipSlashed = 4
    }

    /// <summary>
    /// >> 8140 - Variant[pallet_tips.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.primitive_types.H256, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.primitive_types.H256, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}