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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.pallet_indices.pallet
{
    public enum Call
    {
        claim = 0,
        transfer = 1,
        free = 2,
        force_transfer = 3,
        freeze = 4
    }

    /// <summary>
    /// >> 4049 - Variant[pallet_indices.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.Bool>, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}