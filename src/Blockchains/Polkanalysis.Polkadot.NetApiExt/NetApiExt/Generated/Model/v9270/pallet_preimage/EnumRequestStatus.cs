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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.pallet_preimage
{
    public enum RequestStatus
    {
        Unrequested = 0,
        Requested = 1
    }

    /// <summary>
    /// >> 8495 - Variant[pallet_preimage.RequestStatus]
    /// </summary>
    public sealed class EnumRequestStatus : BaseEnumExt<RequestStatus, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}