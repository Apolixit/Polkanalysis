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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.pallet_elections_phragmen
{
    public enum Renouncing
    {
        Member = 0,
        RunnerUp = 1,
        Candidate = 2
    }

    /// <summary>
    /// >> 3404 - Variant[pallet_elections_phragmen.Renouncing]
    /// </summary>
    public sealed class EnumRenouncing : BaseEnumExt<Renouncing, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}