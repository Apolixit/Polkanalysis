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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_utility.pallet
{
    public enum Event
    {
        BatchInterrupted = 0,
        BatchCompleted = 1,
        ItemCompleted = 2,
        DispatchedAs = 3
    }

    /// <summary>
    /// >> 17594 - Variant[pallet_utility.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_runtime.EnumDispatchError>, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.EnumResult>
    {
    }
}