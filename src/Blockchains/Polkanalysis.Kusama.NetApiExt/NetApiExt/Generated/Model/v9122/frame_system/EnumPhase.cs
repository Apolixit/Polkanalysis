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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.frame_system
{
    public enum Phase
    {
        ApplyExtrinsic = 0,
        Finalization = 1,
        Initialization = 2
    }

    /// <summary>
    /// >> 19106 - Variant[frame_system.Phase]
    /// </summary>
    public sealed class EnumPhase : BaseEnumExt<Phase, Substrate.NetApi.Model.Types.Primitive.U32, BaseVoid, BaseVoid>
    {
    }
}