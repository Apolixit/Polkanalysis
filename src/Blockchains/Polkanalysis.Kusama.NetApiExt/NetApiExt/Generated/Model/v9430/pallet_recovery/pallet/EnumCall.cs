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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_recovery.pallet
{
    public enum Call
    {
        as_recovered = 0,
        set_recovered = 1,
        create_recovery = 2,
        initiate_recovery = 3,
        vouch_recovery = 4,
        claim_recovery = 5,
        close_recovery = 6,
        remove_recovery = 7,
        cancel_recovered = 8
    }

    /// <summary>
    /// >> 200 - Variant[pallet_recovery.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.kusama_runtime.EnumRuntimeCall>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress>
    {
    }
}