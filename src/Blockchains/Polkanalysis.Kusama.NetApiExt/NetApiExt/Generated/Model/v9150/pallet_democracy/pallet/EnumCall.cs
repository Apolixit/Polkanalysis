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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_democracy.pallet
{
    public enum Call
    {
        propose = 0,
        second = 1,
        vote = 2,
        emergency_cancel = 3,
        external_propose = 4,
        external_propose_majority = 5,
        external_propose_default = 6,
        fast_track = 7,
        veto_external = 8,
        cancel_referendum = 9,
        cancel_queued = 10,
        @delegate = 11,
        undelegate = 12,
        clear_public_proposals = 13,
        note_preimage = 14,
        note_preimage_operational = 15,
        note_imminent_preimage = 16,
        note_imminent_preimage_operational = 17,
        reap_preimage = 18,
        unlock = 19,
        remove_vote = 20,
        remove_other_vote = 21,
        enact_proposal = 22,
        blacklist = 23,
        cancel_proposal = 24
    }

    /// <summary>
    /// >> 17830 - Variant[pallet_democracy.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_democracy.vote.EnumAccountVote>, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_democracy.conviction.EnumConviction, Substrate.NetApi.Model.Types.Primitive.U128>, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}