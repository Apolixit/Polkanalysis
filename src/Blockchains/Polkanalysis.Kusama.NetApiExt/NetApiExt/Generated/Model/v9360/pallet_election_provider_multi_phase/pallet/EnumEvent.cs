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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_election_provider_multi_phase.pallet
{
    public enum Event
    {
        SolutionStored = 0,
        ElectionFinalized = 1,
        ElectionFailed = 2,
        Rewarded = 3,
        Slashed = 4,
        SignedPhaseStarted = 5,
        UnsignedPhaseStarted = 6
    }

    /// <summary>
    /// >> 3914 - Variant[pallet_election_provider_multi_phase.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_election_provider_multi_phase.EnumElectionCompute, Substrate.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_election_provider_multi_phase.EnumElectionCompute, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_npos_elections.ElectionScore>, BaseVoid, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}