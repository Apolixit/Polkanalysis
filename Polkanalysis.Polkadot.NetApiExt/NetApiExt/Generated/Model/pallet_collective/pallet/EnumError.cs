//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_collective.pallet
{
    
    
    public enum Error
    {
        
        NotMember = 0,
        
        DuplicateProposal = 1,
        
        ProposalMissing = 2,
        
        WrongIndex = 3,
        
        DuplicateVote = 4,
        
        AlreadyInitialized = 5,
        
        TooEarly = 6,
        
        TooManyProposals = 7,
        
        WrongProposalWeight = 8,
        
        WrongProposalLength = 9,
    }
    
    /// <summary>
    /// >> 549 - Variant[pallet_collective.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
