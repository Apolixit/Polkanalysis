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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime
{
    public enum ProxyType
    {
        Any = 0,
        NonTransfer = 1,
        Governance = 2,
        Staking = 3,
        IdentityJudgement = 5,
        CancelProxy = 6,
        Auction = 7
    }

    /// <summary>
    /// >> 7431 - Variant[polkadot_runtime.ProxyType]
    /// </summary>
    public sealed class EnumProxyType : BaseEnum<ProxyType>
    {
    }
}