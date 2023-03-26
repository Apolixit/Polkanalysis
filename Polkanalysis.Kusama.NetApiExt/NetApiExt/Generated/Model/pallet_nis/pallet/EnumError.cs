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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_nis.pallet
{
    
    
    public enum Error
    {
        
        DurationTooSmall = 0,
        
        DurationTooBig = 1,
        
        AmountTooSmall = 2,
        
        BidTooLow = 3,
        
        Unknown = 4,
        
        NotOwner = 5,
        
        NotExpired = 6,
        
        NotFound = 7,
        
        TooMuch = 8,
        
        Unfunded = 9,
        
        Funded = 10,
        
        Throttled = 11,
        
        MakesDust = 12,
    }
    
    /// <summary>
    /// >> 728 - Variant[pallet_nis.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
