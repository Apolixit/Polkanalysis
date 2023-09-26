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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.polkadot_runtime_common.claims.pallet
{
    public enum Error
    {
        InvalidEthereumSignature = 0,
        SignerHasNoClaim = 1,
        SenderHasNoClaim = 2,
        PotUnderflow = 3,
        InvalidStatement = 4,
        VestedBalanceExists = 5
    }

    /// <summary>
    /// >> 17367 - Variant[polkadot_runtime_common.claims.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}