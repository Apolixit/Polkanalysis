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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.polkadot_runtime_common.paras_registrar.pallet
{
    public enum Event
    {
        Registered = 0,
        Deregistered = 1,
        Reserved = 2
    }

    /// <summary>
    /// >> 6502 - Variant[polkadot_runtime_common.paras_registrar.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.sp_core.crypto.AccountId32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.sp_core.crypto.AccountId32>>
    {
    }
}