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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_conviction_voting.pallet
{
    public enum Call
    {
        vote = 0,
        @delegate = 1,
        undelegate = 2,
        unlock = 3,
        remove_vote = 4,
        remove_other_vote = 5
    }

    /// <summary>
    /// >> 1869 - Variant[pallet_conviction_voting.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_conviction_voting.vote.EnumAccountVote>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_conviction_voting.conviction.EnumConviction, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U16, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_runtime.multiaddress.EnumMultiAddress>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U16>, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}