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


namespace Substats.Bajun.NetApiExt.Generated.Model.pallet_multisig.pallet
{
    
    
    public enum Event
    {
        
        NewMultisig = 0,
        
        MultisigApproval = 1,
        
        MultisigExecuted = 2,
        
        MultisigCancelled = 3,
    }
    
    /// <summary>
    /// >> 28 - Variant[pallet_multisig.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8>, BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_multisig.Timepoint, Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8>, BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_multisig.Timepoint, Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8, Substats.Bajun.NetApiExt.Generated.Types.Base.EnumResult>, BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_multisig.Timepoint, Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8>>
    {
    }
}