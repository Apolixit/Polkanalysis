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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_democracy.pallet
{
    
    
    public enum Error
    {
        
        ValueLow = 0,
        
        ProposalMissing = 1,
        
        AlreadyCanceled = 2,
        
        DuplicateProposal = 3,
        
        ProposalBlacklisted = 4,
        
        NotSimpleMajority = 5,
        
        InvalidHash = 6,
        
        NoProposal = 7,
        
        AlreadyVetoed = 8,
        
        ReferendumInvalid = 9,
        
        NoneWaiting = 10,
        
        NotVoter = 11,
        
        NoPermission = 12,
        
        AlreadyDelegating = 13,
        
        InsufficientFunds = 14,
        
        NotDelegating = 15,
        
        VotesExist = 16,
        
        InstantNotAllowed = 17,
        
        Nonsense = 18,
        
        WrongUpperBound = 19,
        
        MaxVotesReached = 20,
        
        TooMany = 21,
        
        VotingPeriodLow = 22,
    }
    
    /// <summary>
    /// >> 590 - Variant[pallet_democracy.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
