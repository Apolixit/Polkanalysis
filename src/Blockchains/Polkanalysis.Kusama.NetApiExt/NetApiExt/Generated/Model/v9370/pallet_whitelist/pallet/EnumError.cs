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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.pallet_whitelist.pallet
{
    public enum Error
    {
        UnavailablePreImage = 0,
        UndecodableCall = 1,
        InvalidCallWeightWitness = 2,
        CallIsNotWhitelisted = 3,
        CallAlreadyWhitelisted = 4
    }

    /// <summary>
    /// >> 3244 - Variant[pallet_whitelist.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}