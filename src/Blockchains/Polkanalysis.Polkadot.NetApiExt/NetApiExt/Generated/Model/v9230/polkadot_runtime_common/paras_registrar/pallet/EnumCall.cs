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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime_common.paras_registrar.pallet
{
    public enum Call
    {
        register = 0,
        force_register = 1,
        deregister = 2,
        swap = 3,
        force_remove_lock = 4,
        reserve = 5
    }

    /// <summary>
    /// >> 6353 - Variant[polkadot_runtime_common.paras_registrar.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.HeadData, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.ValidationCode>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.HeadData, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.ValidationCode>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id, BaseVoid>
    {
    }
}