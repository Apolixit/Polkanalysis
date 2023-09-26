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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_elections_phragmen.pallet
{
    public enum Event
    {
        NewTerm = 0,
        EmptyTerm = 1,
        ElectionError = 2,
        MemberKicked = 3,
        Renounced = 4,
        CandidateSlashed = 5,
        SeatHolderSlashed = 6
    }

    /// <summary>
    /// >> 17586 - Variant[pallet_elections_phragmen.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}