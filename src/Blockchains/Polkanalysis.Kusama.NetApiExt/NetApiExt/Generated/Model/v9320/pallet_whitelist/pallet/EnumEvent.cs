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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_whitelist.pallet
{
    public enum Event
    {
        CallWhitelisted = 0,
        WhitelistedCallRemoved = 1,
        WhitelistedCallDispatched = 2
    }

    /// <summary>
    /// >> 6466 - Variant[pallet_whitelist.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.primitive_types.H256, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.EnumResult>>
    {
    }
}