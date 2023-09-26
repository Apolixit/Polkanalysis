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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_conviction_voting.pallet
{
    public enum Error
    {
        NotOngoing = 0,
        NotVoter = 1,
        NoPermission = 2,
        NoPermissionYet = 3,
        AlreadyDelegating = 4,
        AlreadyVoting = 5,
        InsufficientFunds = 6,
        NotDelegating = 7,
        Nonsense = 8,
        MaxVotesReached = 9,
        ClassNeeded = 10,
        BadClass = 11
    }

    /// <summary>
    /// >> 4071 - Variant[pallet_conviction_voting.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}