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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_collective.pallet
{
    
    
    public enum Call
    {
        
        set_members = 0,
        
        execute = 1,
        
        propose = 2,
        
        vote = 3,
        
        close = 4,
        
        disapprove_proposal = 5,
    }
    
    /// <summary>
    /// >> 271 - Variant[pallet_collective.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.bajun_runtime.EnumCall, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>>, BaseTuple<Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Bajun.NetApiExt.Generated.Model.bajun_runtime.EnumCall, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>, Ajuna.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U64>, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>>, Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>
    {
    }
}
