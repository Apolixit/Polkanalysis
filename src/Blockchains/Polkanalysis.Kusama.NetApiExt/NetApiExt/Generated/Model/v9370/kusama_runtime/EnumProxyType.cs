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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.kusama_runtime
{
    public enum ProxyType
    {
        Any = 0,
        NonTransfer = 1,
        Governance = 2,
        Staking = 3,
        IdentityJudgement = 4,
        CancelProxy = 5,
        Auction = 6,
        Society = 7
    }

    /// <summary>
    /// >> 2827 - Variant[kusama_runtime.ProxyType]
    /// </summary>
    public sealed class EnumProxyType : BaseEnum<ProxyType>
    {
    }
}