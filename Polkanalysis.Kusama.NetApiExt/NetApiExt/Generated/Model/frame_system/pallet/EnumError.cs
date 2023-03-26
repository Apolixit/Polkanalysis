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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.frame_system.pallet
{
    
    
    public enum Error
    {
        
        InvalidSpecName = 0,
        
        SpecVersionNeedsToIncrease = 1,
        
        FailedToExtractRuntimeVersion = 2,
        
        NonDefaultComposite = 3,
        
        NonZeroRefCount = 4,
        
        CallFiltered = 5,
    }
    
    /// <summary>
    /// >> 502 - Variant[frame_system.pallet.Error]
    /// Error for the System pallet
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
