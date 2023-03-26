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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_preimage.pallet
{
    
    
    public enum Error
    {
        
        TooBig = 0,
        
        AlreadyNoted = 1,
        
        NotAuthorized = 2,
        
        NotNoted = 3,
        
        Requested = 4,
        
        NotRequested = 5,
    }
    
    /// <summary>
    /// >> 699 - Variant[pallet_preimage.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
