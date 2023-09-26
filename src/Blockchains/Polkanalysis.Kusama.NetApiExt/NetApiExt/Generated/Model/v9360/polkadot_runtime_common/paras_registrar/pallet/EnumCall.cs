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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_runtime_common.paras_registrar.pallet
{
    public enum Call
    {
        register = 0,
        force_register = 1,
        deregister = 2,
        swap = 3,
        remove_lock = 4,
        reserve = 5,
        add_lock = 6,
        schedule_code_upgrade = 7,
        set_current_head = 8
    }

    /// <summary>
    /// >> 3827 - Variant[polkadot_runtime_common.paras_registrar.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.HeadData, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.ValidationCode>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.HeadData, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.ValidationCode>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.ValidationCode>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_parachain.primitives.HeadData>>
    {
    }
}