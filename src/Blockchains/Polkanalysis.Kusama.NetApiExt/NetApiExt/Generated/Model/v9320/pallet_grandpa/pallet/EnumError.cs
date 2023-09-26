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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_grandpa.pallet
{
    public enum Error
    {
        PauseFailed = 0,
        ResumeFailed = 1,
        ChangePending = 2,
        TooSoon = 3,
        InvalidKeyOwnershipProof = 4,
        InvalidEquivocationProof = 5,
        DuplicateOffenceReport = 6
    }

    /// <summary>
    /// >> 6587 - Variant[pallet_grandpa.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}