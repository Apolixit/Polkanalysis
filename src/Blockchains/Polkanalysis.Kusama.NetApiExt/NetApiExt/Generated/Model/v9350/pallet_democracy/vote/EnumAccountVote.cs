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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.pallet_democracy.vote
{
    public enum AccountVote
    {
        Standard = 0,
        Split = 1
    }

    /// <summary>
    /// >> 4366 - Variant[pallet_democracy.vote.AccountVote]
    /// </summary>
    public sealed class EnumAccountVote : BaseEnumExt<AccountVote, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.pallet_democracy.vote.Vote, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}