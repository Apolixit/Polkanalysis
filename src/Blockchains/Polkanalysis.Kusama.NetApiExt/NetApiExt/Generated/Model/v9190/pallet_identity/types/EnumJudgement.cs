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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.pallet_identity.types
{
    public enum Judgement
    {
        Unknown = 0,
        FeePaid = 1,
        Reasonable = 2,
        KnownGood = 3,
        OutOfDate = 4,
        LowQuality = 5,
        Erroneous = 6
    }

    /// <summary>
    /// >> 14225 - Variant[pallet_identity.types.Judgement]
    /// </summary>
    public sealed class EnumJudgement : BaseEnumExt<Judgement, BaseVoid, Substrate.NetApi.Model.Types.Primitive.U128, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
    }
}