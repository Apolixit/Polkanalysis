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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_multisig.pallet
{
    public enum Event
    {
        NewMultisig = 0,
        MultisigApproval = 1,
        MultisigExecuted = 2,
        MultisigCancelled = 3
    }

    /// <summary>
    /// >> 1337 - Variant[pallet_multisig.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_multisig.Timepoint, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_multisig.Timepoint, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.EnumResult>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_multisig.Timepoint, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8>>
    {
    }
}