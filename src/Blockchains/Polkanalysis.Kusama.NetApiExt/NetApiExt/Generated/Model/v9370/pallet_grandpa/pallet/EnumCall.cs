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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.pallet_grandpa.pallet
{
    public enum Call
    {
        report_equivocation = 0,
        report_equivocation_unsigned = 1,
        note_stalled = 2
    }

    /// <summary>
    /// >> 2708 - Variant[pallet_grandpa.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.sp_finality_grandpa.EquivocationProof, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.sp_session.MembershipProof>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.sp_finality_grandpa.EquivocationProof, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.sp_session.MembershipProof>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}