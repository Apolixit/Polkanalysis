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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.pallet_grandpa.pallet
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
    /// >> 3668 - Variant[pallet_grandpa.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}