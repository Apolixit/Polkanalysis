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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.pallet
{
    public enum Call
    {
        claim = 0,
        mint_claim = 1,
        claim_attest = 2,
        attest = 3,
        move_claim = 4
    }

    /// <summary>
    /// >> 14070 - Variant[polkadot_runtime_common.claims.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EcdsaSignature>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EnumStatementKind>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EcdsaSignature, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32>>>
    {
    }
}