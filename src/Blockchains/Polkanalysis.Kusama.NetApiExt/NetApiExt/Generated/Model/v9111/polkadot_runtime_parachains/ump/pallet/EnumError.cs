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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_runtime_parachains.ump.pallet
{
    public enum Error
    {
        UnknownMessageIndex = 0,
        WeightOverLimit = 1
    }

    /// <summary>
    /// >> 20331 - Variant[polkadot_runtime_parachains.ump.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://substrate.dev/docs/en/knowledgebase/runtime/errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}