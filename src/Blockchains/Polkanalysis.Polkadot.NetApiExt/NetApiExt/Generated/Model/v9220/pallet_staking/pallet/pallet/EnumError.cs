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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.pallet_staking.pallet.pallet
{
    public enum Error
    {
        NotController = 0,
        NotStash = 1,
        AlreadyBonded = 2,
        AlreadyPaired = 3,
        EmptyTargets = 4,
        DuplicateIndex = 5,
        InvalidSlashIndex = 6,
        InsufficientBond = 7,
        NoMoreChunks = 8,
        NoUnlockChunk = 9,
        FundedTarget = 10,
        InvalidEraToReward = 11,
        InvalidNumberOfNominations = 12,
        NotSortedAndUnique = 13,
        AlreadyClaimed = 14,
        IncorrectHistoryDepth = 15,
        IncorrectSlashingSpans = 16,
        BadState = 17,
        TooManyTargets = 18,
        BadTarget = 19,
        CannotChillOther = 20,
        TooManyNominators = 21,
        TooManyValidators = 22,
        CommissionTooLow = 23
    }

    /// <summary>
    /// >> 5746 - Variant[pallet_staking.pallet.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}