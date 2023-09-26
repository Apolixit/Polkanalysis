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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.pallet
{
    public enum Call
    {
        vote = 0,
        remove_voter = 1,
        submit_candidacy = 2,
        renounce_candidacy = 3,
        remove_member = 4,
        clean_defunct_voters = 5
    }

    /// <summary>
    /// >> 12649 - Variant[pallet_elections_phragmen.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.EnumRenouncing, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}