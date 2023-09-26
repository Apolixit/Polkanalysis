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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_democracy.pallet
{
    public enum Event
    {
        Proposed = 0,
        Tabled = 1,
        ExternalTabled = 2,
        Started = 3,
        Passed = 4,
        NotPassed = 5,
        Cancelled = 6,
        Executed = 7,
        Delegated = 8,
        Undelegated = 9,
        Vetoed = 10,
        PreimageNoted = 11,
        PreimageUsed = 12,
        PreimageInvalid = 13,
        PreimageMissing = 14,
        PreimageReaped = 15,
        Blacklisted = 16
    }

    /// <summary>
    /// >> 16862 - Variant[pallet_democracy.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32>>, BaseVoid, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_democracy.vote_threshold.EnumVoteThreshold>, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.EnumResult>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.primitive_types.H256>
    {
    }
}