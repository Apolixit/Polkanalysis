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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_grandpa.pallet
{
    public enum Event
    {
        NewAuthorities = 0,
        Paused = 1,
        Resumed = 2
    }

    /// <summary>
    /// >> 9531 - Variant[pallet_grandpa.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>, BaseVoid, BaseVoid>
    {
    }
}