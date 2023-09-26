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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.polkadot_runtime_parachains.inclusion.pallet
{
    public enum Error
    {
        WrongBitfieldSize = 0,
        BitfieldDuplicateOrUnordered = 1,
        ValidatorIndexOutOfBounds = 2,
        InvalidBitfieldSignature = 3,
        UnscheduledCandidate = 4,
        CandidateScheduledBeforeParaFree = 5,
        WrongCollator = 6,
        ScheduledOutOfOrder = 7,
        HeadDataTooLarge = 8,
        PrematureCodeUpgrade = 9,
        NewCodeTooLarge = 10,
        CandidateNotInParentContext = 11,
        InvalidGroupIndex = 12,
        InsufficientBacking = 13,
        InvalidBacking = 14,
        NotCollatorSigned = 15,
        ValidationDataHashMismatch = 16,
        IncorrectDownwardMessageHandling = 17,
        InvalidUpwardMessages = 18,
        HrmpWatermarkMishandling = 19,
        InvalidOutboundHrmp = 20,
        InvalidValidationCodeHash = 21,
        ParaHeadMismatch = 22,
        BitfieldReferencesFreedCore = 23
    }

    /// <summary>
    /// >> 17446 - Variant[polkadot_runtime_parachains.inclusion.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}