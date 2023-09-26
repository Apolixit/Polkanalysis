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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.paras.pallet
{
    public enum Error
    {
        NotRegistered = 0,
        CannotOnboard = 1,
        CannotOffboard = 2,
        CannotUpgrade = 3,
        CannotDowngrade = 4,
        PvfCheckStatementStale = 5,
        PvfCheckStatementFuture = 6,
        PvfCheckValidatorIndexOutOfBounds = 7,
        PvfCheckInvalidSignature = 8,
        PvfCheckDoubleVote = 9,
        PvfCheckSubjectInvalid = 10,
        PvfCheckDisabled = 11
    }

    /// <summary>
    /// >> 3116 - Variant[polkadot_runtime_parachains.paras.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}