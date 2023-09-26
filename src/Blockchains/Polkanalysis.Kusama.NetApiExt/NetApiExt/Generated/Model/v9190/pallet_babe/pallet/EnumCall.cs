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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.pallet_babe.pallet
{
    public enum Call
    {
        report_equivocation = 0,
        report_equivocation_unsigned = 1,
        plan_config_change = 2
    }

    /// <summary>
    /// >> 14036 - Variant[pallet_babe.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_consensus_slots.EquivocationProof, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_session.MembershipProof>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_consensus_slots.EquivocationProof, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_session.MembershipProof>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_consensus_babe.digests.EnumNextConfigDescriptor>
    {
    }
}