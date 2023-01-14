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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.pallet
{
    
    
    public enum Call
    {
        
        submit_unsigned = 0,
        
        set_minimum_untrusted_score = 1,
        
        set_emergency_election_result = 2,
        
        submit = 3,
        
        governance_fallback = 4,
    }
    
    /// <summary>
    /// >> 238 - Variant[pallet_election_provider_multi_phase.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RawSolution, Substats.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Substats.Kusama.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore>, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_npos_elections.Support>>, Substats.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RawSolution, BaseTuple<Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32>>>
    {
    }
}
