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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_democracy.types
{
    public enum ReferendumInfo
    {
        Ongoing = 0,
        Finished = 1
    }

    /// <summary>
    /// >> 12631 - Variant[pallet_democracy.types.ReferendumInfo]
    /// </summary>
    public sealed class EnumReferendumInfo : BaseEnumExt<ReferendumInfo, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_democracy.types.ReferendumStatus, BaseTuple<Substrate.NetApi.Model.Types.Primitive.Bool, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}