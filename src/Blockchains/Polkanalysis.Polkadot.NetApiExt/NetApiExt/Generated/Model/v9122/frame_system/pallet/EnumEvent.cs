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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.frame_system.pallet
{
    public enum Event
    {
        ExtrinsicSuccess = 0,
        ExtrinsicFailed = 1,
        CodeUpdated = 2,
        NewAccount = 3,
        KilledAccount = 4,
        Remarked = 5
    }

    /// <summary>
    /// >> 608 - Variant[frame_system.pallet.Event]
    /// Event for the System pallet.
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.frame_support.weights.DispatchInfo, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_runtime.EnumDispatchError, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.frame_support.weights.DispatchInfo>, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256>>
    {
    }
}