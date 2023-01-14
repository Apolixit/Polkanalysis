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


namespace Substats.Polkadot.NetApiExt.Generated.Model.frame_system.pallet
{
    
    
    public enum Event
    {
        
        ExtrinsicSuccess = 0,
        
        ExtrinsicFailed = 1,
        
        CodeUpdated = 2,
        
        NewAccount = 3,
        
        KilledAccount = 4,
        
        Remarked = 5,
    }
    
    /// <summary>
    /// >> 19 - Variant[frame_system.pallet.Event]
    /// Event for the System pallet.
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.DispatchInfo, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.EnumDispatchError, Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.DispatchInfo>, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256>>
    {
    }
}
