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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_proxy.pallet
{
    public enum Event
    {
        ProxyExecuted = 0,
        AnonymousCreated = 1,
        Announced = 2,
        ProxyAdded = 3,
        ProxyRemoved = 4
    }

    /// <summary>
    /// >> 4634 - Variant[pallet_proxy.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.EnumResult, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U16>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.primitive_types.H256>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}