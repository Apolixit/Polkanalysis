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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_membership.pallet
{
    public enum Call
    {
        add_member = 0,
        remove_member = 1,
        swap_member = 2,
        reset_members = 3,
        change_key = 4,
        set_prime = 5,
        clear_prime = 6
    }

    /// <summary>
    /// >> 9725 - Variant[pallet_membership.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32, BaseVoid>
    {
    }
}