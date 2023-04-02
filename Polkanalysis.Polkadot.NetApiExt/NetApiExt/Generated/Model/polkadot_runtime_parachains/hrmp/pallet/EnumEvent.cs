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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.hrmp.pallet
{
    
    
    public enum Event
    {
        
        OpenChannelRequested = 0,
        
        OpenChannelCanceled = 1,
        
        OpenChannelAccepted = 2,
        
        ChannelClosed = 3,
        
        HrmpChannelForceOpened = 4,
    }
    
    /// <summary>
    /// >> 114 - Variant[polkadot_runtime_parachains.hrmp.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HrmpChannelId>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HrmpChannelId>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
    }
}