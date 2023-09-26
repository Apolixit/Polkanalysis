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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.pallet_proxy.pallet
{
    public enum Event
    {
        ProxyExecuted = 0,
        AnonymousCreated = 1,
        Announced = 2,
        ProxyAdded = 3
    }

    /// <summary>
    /// >> 16156 - Variant[pallet_proxy.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.EnumResult, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.kusama_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U16>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.primitive_types.H256>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.kusama_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}