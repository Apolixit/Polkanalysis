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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_multisig.pallet
{
    public enum Error
    {
        MinimumThreshold = 0,
        AlreadyApproved = 1,
        NoApprovalsNeeded = 2,
        TooFewSignatories = 3,
        TooManySignatories = 4,
        SignatoriesOutOfOrder = 5,
        SenderInSignatories = 6,
        NotFound = 7,
        NotOwner = 8,
        NoTimepoint = 9,
        WrongTimepoint = 10,
        UnexpectedTimepoint = 11,
        MaxWeightTooLow = 12,
        AlreadyStored = 13
    }

    /// <summary>
    /// >> 15389 - Variant[pallet_multisig.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}