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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_transaction_payment.pallet
{
    public enum Event
    {
        TransactionFeePaid = 0
    }

    /// <summary>
    /// >> 12455 - Variant[pallet_transaction_payment.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}