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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_election_provider_multi_phase
{
    public enum ElectionCompute
    {
        OnChain = 0,
        Signed = 1,
        Unsigned = 2,
        Fallback = 3,
        Emergency = 4
    }

    /// <summary>
    /// >> 6486 - Variant[pallet_election_provider_multi_phase.ElectionCompute]
    /// </summary>
    public sealed class EnumElectionCompute : BaseEnum<ElectionCompute>
    {
    }
}