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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_babe.pallet
{
    
    
    public enum Call
    {
        
        report_equivocation = 0,
        
        report_equivocation_unsigned = 1,
        
        plan_config_change = 2,
    }
    
    /// <summary>
    /// >> 188 - Variant[pallet_babe.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_slots.EquivocationProof, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_session.MembershipProof>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_slots.EquivocationProof, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_session.MembershipProof>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumNextConfigDescriptor>
    {
    }
}
