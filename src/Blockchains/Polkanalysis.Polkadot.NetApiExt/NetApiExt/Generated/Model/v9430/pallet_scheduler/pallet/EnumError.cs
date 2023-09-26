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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_scheduler.pallet
{
    public enum Error
    {
        FailedToSchedule = 0,
        NotFound = 1,
        TargetBlockNumberInPast = 2,
        RescheduleNoChange = 3,
        Named = 4
    }

    /// <summary>
    /// >> 15216 - Variant[pallet_scheduler.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}