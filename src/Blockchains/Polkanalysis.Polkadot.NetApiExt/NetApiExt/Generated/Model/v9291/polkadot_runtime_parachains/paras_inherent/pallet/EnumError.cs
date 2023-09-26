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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.polkadot_runtime_parachains.paras_inherent.pallet
{
    public enum Error
    {
        TooManyInclusionInherents = 0,
        InvalidParentHeader = 1,
        CandidateConcludedInvalid = 2,
        InherentOverweight = 3,
        DisputeStatementsUnsortedOrDuplicates = 4,
        DisputeInvalid = 5
    }

    /// <summary>
    /// >> 10856 - Variant[polkadot_runtime_parachains.paras_inherent.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}