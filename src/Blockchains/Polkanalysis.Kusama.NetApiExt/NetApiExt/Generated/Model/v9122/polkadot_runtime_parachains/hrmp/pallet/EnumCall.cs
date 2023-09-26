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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_runtime_parachains.hrmp.pallet
{
    public enum Call
    {
        hrmp_init_open_channel = 0,
        hrmp_accept_open_channel = 1,
        hrmp_close_channel = 2,
        force_clean_hrmp = 3,
        force_process_hrmp_open = 4,
        force_process_hrmp_close = 5,
        hrmp_cancel_open_request = 6
    }

    /// <summary>
    /// >> 19454 - Variant[polkadot_runtime_parachains.hrmp.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_parachain.primitives.HrmpChannelId, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_parachain.primitives.Id, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_parachain.primitives.HrmpChannelId>
    {
    }
}