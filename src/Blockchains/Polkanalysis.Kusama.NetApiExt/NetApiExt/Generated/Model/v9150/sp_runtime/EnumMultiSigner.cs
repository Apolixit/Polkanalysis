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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_runtime
{
    public enum MultiSigner
    {
        Ed25519 = 0,
        Sr25519 = 1,
        Ecdsa = 2
    }

    /// <summary>
    /// >> 18038 - Variant[sp_runtime.MultiSigner]
    /// </summary>
    public sealed class EnumMultiSigner : BaseEnumExt<MultiSigner, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.ed25519.Public, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.sr25519.Public, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.ecdsa.Public>
    {
    }
}