//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.pallet
{
    
    
    public enum Event
    {
        
        Registered = 0,
        
        Deregistered = 1,
        
        Reserved = 2,
    }
    
    /// <summary>
    /// >> 117 - Variant[polkadot_runtime_common.paras_registrar.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>>
    {
    }
}
