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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.pallet_collective.pallet
{
    public enum Call
    {
        set_members = 0,
        execute = 1,
        propose = 2,
        vote = 3,
        close = 4,
        disapprove_proposal = 5
    }

    /// <summary>
    /// >> 11181 - Variant[pallet_collective.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_runtime.EnumRuntimeCall, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_runtime.EnumRuntimeCall, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_weights.weight_v2.Weight>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.primitive_types.H256>
    {
    }
}