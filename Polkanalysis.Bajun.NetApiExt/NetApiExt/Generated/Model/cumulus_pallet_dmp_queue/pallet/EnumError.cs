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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_dmp_queue.pallet
{
    
    
    public enum Error
    {
        
        Unknown = 0,
        
        OverLimit = 1,
    }
    
    /// <summary>
    /// >> 361 - Variant[cumulus_pallet_dmp_queue.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
