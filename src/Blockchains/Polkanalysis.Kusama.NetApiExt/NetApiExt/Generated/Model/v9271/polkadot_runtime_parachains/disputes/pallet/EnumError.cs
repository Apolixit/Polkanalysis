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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.polkadot_runtime_parachains.disputes.pallet
{
    public enum Error
    {
        DuplicateDisputeStatementSets = 0,
        AncientDisputeStatement = 1,
        ValidatorIndexOutOfBounds = 2,
        InvalidSignature = 3,
        DuplicateStatement = 4,
        PotentialSpam = 5,
        SingleSidedDispute = 6
    }

    /// <summary>
    /// >> 9960 - Variant[polkadot_runtime_parachains.disputes.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}