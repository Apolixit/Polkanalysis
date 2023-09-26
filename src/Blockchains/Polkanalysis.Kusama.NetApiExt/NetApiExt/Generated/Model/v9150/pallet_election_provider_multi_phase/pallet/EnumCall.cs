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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_election_provider_multi_phase.pallet
{
    public enum Call
    {
        submit_unsigned = 0,
        set_minimum_untrusted_score = 1,
        set_emergency_election_result = 2,
        submit = 3
    }

    /// <summary>
    /// >> 17910 - Variant[pallet_election_provider_multi_phase.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_election_provider_multi_phase.RawSolution, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_election_provider_multi_phase.SolutionOrSnapshotSize>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr3U128>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_npos_elections.Support>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_election_provider_multi_phase.RawSolution, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}