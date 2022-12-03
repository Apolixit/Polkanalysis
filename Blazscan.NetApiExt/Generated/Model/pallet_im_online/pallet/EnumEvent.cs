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


namespace Blazscan.NetApiExt.Generated.Model.pallet_im_online.pallet
{
    
    
    public enum Event
    {
        
        HeartbeatReceived = 0,
        
        AllGood = 1,
        
        SomeOffline = 2,
    }
    
    /// <summary>
    /// >> 52 - Variant[pallet_im_online.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Blazscan.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public, BaseVoid, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Blazscan.NetApiExt.Generated.Model.pallet_staking.Exposure>>>
    {
    }
}
