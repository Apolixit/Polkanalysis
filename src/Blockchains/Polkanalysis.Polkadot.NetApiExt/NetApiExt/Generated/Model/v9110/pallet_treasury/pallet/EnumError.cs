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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.pallet_treasury.pallet
{
    public enum Error
    {
        InsufficientProposersBalance = 0,
        InvalidIndex = 1,
        TooManyApprovals = 2,
        ProposalNotApproved = 3,
        InsufficientPermission = 3
    }

    /// <summary>
    /// >> 458 - Variant[pallet_treasury.pallet.Error]
    /// Error for the treasury pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}