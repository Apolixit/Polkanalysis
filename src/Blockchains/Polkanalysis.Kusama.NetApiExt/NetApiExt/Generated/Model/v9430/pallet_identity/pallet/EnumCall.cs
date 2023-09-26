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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_identity.pallet
{
    public enum Call
    {
        add_registrar = 0,
        set_identity = 1,
        set_subs = 2,
        clear_identity = 3,
        request_judgement = 4,
        cancel_request = 5,
        set_fee = 6,
        set_account_id = 7,
        set_fields = 8,
        provide_judgement = 9,
        kill_identity = 10,
        add_sub = 11,
        rename_sub = 12,
        remove_sub = 13,
        quit_sub = 14
    }

    /// <summary>
    /// >> 157 - Variant[pallet_identity.pallet.Call]
    /// Identity pallet declaration.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_identity.types.IdentityInfo, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_identity.types.EnumData>>, BaseVoid, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_identity.types.BitFlags>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_identity.types.EnumJudgement, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.primitive_types.H256>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_identity.types.EnumData>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_identity.types.EnumData>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, BaseVoid>
    {
    }
}