//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.ump.pallet
{
    
    
    public enum Error
    {
        
        UnknownMessageIndex = 0,
        
        WeightOverLimit = 1,
    }
    
    /// <summary>
    /// >> 685 - Variant[polkadot_runtime_parachains.ump.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
