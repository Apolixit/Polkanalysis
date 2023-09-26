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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.pallet_balances.pallet
{
    public enum Event
    {
        Endowed = 0,
        DustLost = 1,
        Transfer = 2,
        BalanceSet = 3,
        Reserved = 4,
        Unreserved = 5,
        ReserveRepatriated = 6,
        Deposit = 7,
        Withdraw = 8,
        Slashed = 9
    }

    /// <summary>
    /// >> 3205 - Variant[pallet_balances.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.frame_support.traits.tokens.misc.EnumBalanceStatus>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}