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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.pallet_society.pallet
{
    public enum Call
    {
        bid = 0,
        unbid = 1,
        vouch = 2,
        unvouch = 3,
        vote = 4,
        defender_vote = 5,
        payout = 6,
        found = 7,
        unfound = 8,
        judge_suspended_member = 9,
        judge_suspended_candidate = 10,
        set_max_members = 11
    }

    /// <summary>
    /// >> 20029 - Variant[pallet_society.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.Bool>, Substrate.NetApi.Model.Types.Primitive.Bool, BaseVoid, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>, BaseVoid, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.pallet_society.EnumJudgement>, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}