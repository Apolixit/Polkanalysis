//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.pallet
{
    
    
    public enum Event
    {
        
        Created = 0,
        
        Contributed = 1,
        
        Withdrew = 2,
        
        PartiallyRefunded = 3,
        
        AllRefunded = 4,
        
        Dissolved = 5,
        
        HandleBidResult = 6,
        
        Edited = 7,
        
        MemoUpdated = 8,
        
        AddedToNewRaise = 9,
    }
    
    /// <summary>
    /// >> 123 - Variant[polkadot_runtime_common.crowdloan.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U128>, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Types.Base.EnumResult>, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>
    {
    }
}
