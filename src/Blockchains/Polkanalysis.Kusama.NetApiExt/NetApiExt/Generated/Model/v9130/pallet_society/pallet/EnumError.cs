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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.pallet
{
    public enum Error
    {
        BadPosition = 0,
        NotMember = 1,
        AlreadyMember = 2,
        Suspended = 3,
        NotSuspended = 4,
        NoPayout = 5,
        AlreadyFounded = 6,
        InsufficientPot = 7,
        AlreadyVouching = 8,
        NotVouching = 9,
        Head = 10,
        Founder = 11,
        AlreadyBid = 12,
        AlreadyCandidate = 13,
        NotCandidate = 14,
        MaxMembers = 15,
        NotFounder = 16,
        NotHead = 17
    }

    /// <summary>
    /// >> 18821 - Variant[pallet_society.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}