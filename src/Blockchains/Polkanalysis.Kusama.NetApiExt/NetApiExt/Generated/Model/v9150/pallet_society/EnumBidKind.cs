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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_society
{
    public enum BidKind
    {
        Deposit = 0,
        Vouch = 1
    }

    /// <summary>
    /// >> 18098 - Variant[pallet_society.BidKind]
    /// </summary>
    public sealed class EnumBidKind : BaseEnumExt<BidKind, Substrate.NetApi.Model.Types.Primitive.U128, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}