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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.pallet_babe.pallet
{
    public enum Error
    {
        InvalidEquivocationProof = 0,
        InvalidKeyOwnershipProof = 1,
        DuplicateOffenceReport = 2
    }

    /// <summary>
    /// >> 19856 - Variant[pallet_babe.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://substrate.dev/docs/en/knowledgebase/runtime/errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}