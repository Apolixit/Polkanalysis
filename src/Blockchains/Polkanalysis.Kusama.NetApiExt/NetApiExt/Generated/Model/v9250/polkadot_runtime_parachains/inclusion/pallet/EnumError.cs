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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.polkadot_runtime_parachains.inclusion.pallet
{
    public enum Error
    {
        UnsortedOrDuplicateValidatorIndices = 0,
        UnsortedOrDuplicateDisputeStatementSet = 1,
        UnsortedOrDuplicateBackedCandidates = 2,
        UnexpectedRelayParent = 3,
        WrongBitfieldSize = 4,
        BitfieldAllZeros = 5,
        BitfieldDuplicateOrUnordered = 6,
        ValidatorIndexOutOfBounds = 7,
        InvalidBitfieldSignature = 8,
        UnscheduledCandidate = 9,
        CandidateScheduledBeforeParaFree = 10,
        WrongCollator = 11,
        ScheduledOutOfOrder = 12,
        HeadDataTooLarge = 13,
        PrematureCodeUpgrade = 14,
        NewCodeTooLarge = 15,
        CandidateNotInParentContext = 16,
        InvalidGroupIndex = 17,
        InsufficientBacking = 18,
        InvalidBacking = 19,
        NotCollatorSigned = 20,
        ValidationDataHashMismatch = 21,
        IncorrectDownwardMessageHandling = 22,
        InvalidUpwardMessages = 23,
        HrmpWatermarkMishandling = 24,
        InvalidOutboundHrmp = 25,
        InvalidValidationCodeHash = 26,
        ParaHeadMismatch = 27,
        BitfieldReferencesFreedCore = 28
    }

    /// <summary>
    /// >> 11463 - Variant[polkadot_runtime_parachains.inclusion.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}