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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_bags_list.pallet
{
    public enum Event
    {
        Rebagged = 0,
        ScoreUpdated = 1
    }

    /// <summary>
    /// >> 15176 - Variant[pallet_bags_list.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U64>>
    {
    }
}