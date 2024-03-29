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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.disputes.pallet
{
    
    
    public enum Event
    {
        
        DisputeInitiated = 0,
        
        DisputeConcluded = 1,
        
        DisputeTimedOut = 2,
        
        Revert = 3,
    }
    
    /// <summary>
    /// >> 116 - Variant[polkadot_runtime_parachains.disputes.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_core_primitives.CandidateHash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.disputes.EnumDisputeLocation>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_core_primitives.CandidateHash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.disputes.EnumDisputeResult>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_core_primitives.CandidateHash, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}
