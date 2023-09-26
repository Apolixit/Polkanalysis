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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_vesting.pallet
{
    public enum Call
    {
        vest = 0,
        vest_other = 1,
        vested_transfer = 2,
        force_vested_transfer = 3,
        merge_schedules = 4
    }

    /// <summary>
    /// >> 1070 - Variant[pallet_vesting.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_runtime.multiaddress.EnumMultiAddress, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_vesting.vesting_info.VestingInfo>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_vesting.vesting_info.VestingInfo>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}