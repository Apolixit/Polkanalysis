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


namespace Blazscan.NetApiExt.Generated.Model.polkadot_runtime_parachains.disputes.pallet
{
    
    
    public enum Error
    {
        
        DuplicateDisputeStatementSets = 0,
        
        AncientDisputeStatement = 1,
        
        ValidatorIndexOutOfBounds = 2,
        
        InvalidSignature = 3,
        
        DuplicateStatement = 4,
        
        PotentialSpam = 5,
        
        SingleSidedDispute = 6,
    }
    
    /// <summary>
    /// >> 699 - Variant[polkadot_runtime_parachains.disputes.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
