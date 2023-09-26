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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.polkadot_runtime_parachains.paras.pallet
{
    public enum Error
    {
        NotRegistered = 0,
        CannotOnboard = 1,
        CannotOffboard = 2,
        CannotUpgrade = 3,
        CannotDowngrade = 4
    }

    /// <summary>
    /// >> 17475 - Variant[polkadot_runtime_parachains.paras.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}