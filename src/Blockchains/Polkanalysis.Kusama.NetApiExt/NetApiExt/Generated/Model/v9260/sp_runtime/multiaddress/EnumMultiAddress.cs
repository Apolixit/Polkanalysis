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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_runtime.multiaddress
{
    public enum MultiAddress
    {
        Id = 0,
        Index = 1,
        Raw = 2,
        Address32 = 3,
        Address20 = 4
    }

    /// <summary>
    /// >> 10211 - Variant[sp_runtime.multiaddress.MultiAddress]
    /// </summary>
    public sealed class EnumMultiAddress : BaseEnumExt<MultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Base.BaseTuple>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr20U8>
    {
    }
}