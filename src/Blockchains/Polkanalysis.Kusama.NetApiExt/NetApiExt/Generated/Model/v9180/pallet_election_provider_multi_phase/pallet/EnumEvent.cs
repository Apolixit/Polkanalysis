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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_election_provider_multi_phase.pallet
{
    public enum Event
    {
        SolutionStored = 0,
        ElectionFinalized = 1,
        Rewarded = 2,
        Slashed = 3,
        SignedPhaseStarted = 4,
        UnsignedPhaseStarted = 5
    }

    /// <summary>
    /// >> 14683 - Variant[pallet_election_provider_multi_phase.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_election_provider_multi_phase.EnumElectionCompute, Substrate.NetApi.Model.Types.Primitive.Bool>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_election_provider_multi_phase.EnumElectionCompute>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}