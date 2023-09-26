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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.pallet_membership.pallet
{
    public enum Event
    {
        MemberAdded = 0,
        MemberRemoved = 1,
        MembersSwapped = 2,
        MembersReset = 3,
        KeyChanged = 4,
        Dummy = 5
    }

    /// <summary>
    /// >> 11617 - Variant[pallet_membership.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnum<Event>
    {
    }
}