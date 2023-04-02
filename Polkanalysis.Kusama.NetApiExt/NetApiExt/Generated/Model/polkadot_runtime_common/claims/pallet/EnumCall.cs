//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.pallet
{
    
    
    public enum Call
    {
        
        claim = 0,
        
        mint_claim = 1,
        
        claim_attest = 2,
        
        attest = 3,
        
        move_claim = 4,
    }
    
    /// <summary>
    /// >> 169 - Variant[polkadot_runtime_common.claims.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EcdsaSignature>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EnumStatementKind>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EcdsaSignature, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>>>
    {
    }
}