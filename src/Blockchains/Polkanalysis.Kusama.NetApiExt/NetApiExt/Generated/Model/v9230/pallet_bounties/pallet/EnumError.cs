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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.pallet_bounties.pallet
{
    public enum Error
    {
        InsufficientProposersBalance = 0,
        InvalidIndex = 1,
        ReasonTooBig = 2,
        UnexpectedStatus = 3,
        RequireCurator = 4,
        InvalidValue = 5,
        InvalidFee = 6,
        PendingPayout = 7,
        Premature = 8,
        HasActiveChildBounty = 9,
        TooManyQueued = 10
    }

    /// <summary>
    /// >> 12184 - Variant[pallet_bounties.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}