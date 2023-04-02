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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_indices.pallet
{
    
    
    public enum Error
    {
        
        NotAssigned = 0,
        
        NotOwner = 1,
        
        InUse = 2,
        
        NotTransfer = 3,
        
        Permanent = 4,
    }
    
    /// <summary>
    /// >> 472 - Variant[pallet_indices.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
