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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.sp_runtime
{
    public enum MultiSignature
    {
        Ed25519 = 0,
        Sr25519 = 1,
        Ecdsa = 2
    }

    /// <summary>
    /// >> 13628 - Variant[sp_runtime.MultiSignature]
    /// </summary>
    public sealed class EnumMultiSignature : BaseEnumExt<MultiSignature, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.sp_core.ed25519.Signature, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.sp_core.sr25519.Signature, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.sp_core.ecdsa.Signature>
    {
    }
}