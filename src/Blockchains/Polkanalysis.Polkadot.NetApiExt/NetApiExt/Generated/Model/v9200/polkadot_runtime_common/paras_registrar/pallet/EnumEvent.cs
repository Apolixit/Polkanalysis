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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime_common.paras_registrar.pallet
{
    public enum Event
    {
        Registered = 0,
        Deregistered = 1,
        Reserved = 2
    }

    /// <summary>
    /// >> 4668 - Variant[polkadot_runtime_common.paras_registrar.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32>>
    {
    }
}