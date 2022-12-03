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


namespace Blazscan.NetApiExt.Generated.Model.pallet_fast_unstake.pallet
{
    
    
    public enum Error
    {
        
        NotController = 0,
        
        AlreadyQueued = 1,
        
        NotFullyBonded = 2,
        
        NotQueued = 3,
        
        AlreadyHead = 4,
        
        CallNotAllowed = 5,
    }
    
    /// <summary>
    /// >> 636 - Variant[pallet_fast_unstake.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
