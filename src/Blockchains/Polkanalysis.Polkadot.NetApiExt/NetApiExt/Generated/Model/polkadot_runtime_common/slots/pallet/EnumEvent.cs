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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.slots.pallet
{
    
    
    public enum Event
    {
        
        NewLeasePeriod = 0,
        
        Leased = 1,
    }
    
    /// <summary>
    /// >> 121 - Variant[polkadot_runtime_common.slots.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}