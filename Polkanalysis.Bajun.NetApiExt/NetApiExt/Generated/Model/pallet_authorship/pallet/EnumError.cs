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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_authorship.pallet
{
    
    
    public enum Error
    {
        
        InvalidUncleParent = 0,
        
        UnclesAlreadySet = 1,
        
        TooManyUncles = 2,
        
        GenesisUncle = 3,
        
        TooHighUncle = 4,
        
        UncleAlreadyIncluded = 5,
        
        OldUncle = 6,
    }
    
    /// <summary>
    /// >> 326 - Variant[pallet_authorship.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
