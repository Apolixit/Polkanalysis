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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_fast_unstake.pallet
{
    public enum Call
    {
        register_fast_unstake = 0,
        deregister = 1,
        control = 2
    }

    /// <summary>
    /// >> 3783 - Variant[pallet_fast_unstake.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}