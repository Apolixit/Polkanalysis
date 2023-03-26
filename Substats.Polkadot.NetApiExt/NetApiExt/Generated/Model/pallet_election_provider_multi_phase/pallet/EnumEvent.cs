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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.pallet
{
    
    
    public enum Event
    {
        
        SolutionStored = 0,
        
        ElectionFinalized = 1,
        
        ElectionFailed = 2,
        
        Rewarded = 3,
        
        Slashed = 4,
        
        PhaseTransitioned = 5,
    }
    
    /// <summary>
    /// >> 87 - Variant[pallet_election_provider_multi_phase.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute, Ajuna.NetApi.Model.Types.Base.BaseOpt<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Ajuna.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute, Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore>, BaseVoid, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase, Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase, Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
    }
}
