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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_proxy.pallet
{
    public enum Error
    {
        TooMany = 0,
        NotFound = 1,
        NotProxy = 2,
        Unproxyable = 3,
        Duplicate = 4,
        NoPermission = 5,
        Unannounced = 6,
        NoSelfProxy = 7
    }

    /// <summary>
    /// >> 10619 - Variant[pallet_proxy.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}