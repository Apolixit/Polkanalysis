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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.pallet_tips.pallet
{
    public enum Call
    {
        report_awesome = 0,
        retract_tip = 1,
        tip_new = 2,
        tip = 3,
        close_tip = 4,
        slash_tip = 5
    }

    /// <summary>
    /// >> 20041 - Variant[pallet_tips.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.primitive_types.H256, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.primitive_types.H256>
    {
    }
}