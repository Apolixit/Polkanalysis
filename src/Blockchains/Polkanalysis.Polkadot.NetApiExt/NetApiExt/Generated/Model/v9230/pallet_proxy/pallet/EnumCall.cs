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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.pallet_proxy.pallet
{
    public enum Call
    {
        proxy = 0,
        add_proxy = 1,
        remove_proxy = 2,
        remove_proxies = 3,
        anonymous = 4,
        kill_anonymous = 5,
        announce = 6,
        remove_announcement = 7,
        reject_announcement = 8,
        proxy_announced = 9
    }

    /// <summary>
    /// >> 6249 - Variant[pallet_proxy.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumProxyType>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumCall>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32>, BaseVoid, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U16>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumProxyType>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime.EnumCall>>
    {
    }
}