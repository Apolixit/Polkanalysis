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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime
{
    
    
    public enum MultiSignature
    {
        
        Ed25519 = 0,
        
        Sr25519 = 1,
        
        Ecdsa = 2,
    }
    
    /// <summary>
    /// >> 378 - Variant[sp_runtime.MultiSignature]
    /// </summary>
    public sealed class EnumMultiSignature : BaseEnumExt<MultiSignature, Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.ed25519.Signature, Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.sr25519.Signature, Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.ecdsa.Signature>
    {
    }
}
