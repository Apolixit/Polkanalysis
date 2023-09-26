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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_multisig.pallet
{
    public enum Event
    {
        NewMultisig = 0,
        MultisigApproval = 1,
        MultisigExecuted = 2,
        MultisigCancelled = 3
    }

    /// <summary>
    /// >> 12498 - Variant[pallet_multisig.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_multisig.Timepoint, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_multisig.Timepoint, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.EnumResult>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_multisig.Timepoint, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>>
    {
    }
}