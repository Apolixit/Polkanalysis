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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.polkadot_runtime_common.paras_registrar.pallet
{
    public enum Error
    {
        NotRegistered = 0,
        AlreadyRegistered = 1,
        NotOwner = 2,
        CodeTooLarge = 3,
        HeadDataTooLarge = 4,
        NotParachain = 5,
        NotParathread = 6,
        CannotDeregister = 7,
        CannotDowngrade = 8,
        CannotUpgrade = 9,
        ParaLocked = 10,
        NotReserved = 11,
        EmptyCode = 12,
        CannotSwap = 13
    }

    /// <summary>
    /// >> 15310 - Variant[polkadot_runtime_common.paras_registrar.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}