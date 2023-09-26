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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.pallet_collective.pallet
{
    public enum Event
    {
        Proposed = 0,
        Voted = 1,
        Approved = 2,
        Disapproved = 3,
        Executed = 4,
        MemberExecuted = 5,
        Closed = 6
    }

    /// <summary>
    /// >> 10279 - Variant[pallet_collective.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.Bool, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.EnumResult>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.EnumResult>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}