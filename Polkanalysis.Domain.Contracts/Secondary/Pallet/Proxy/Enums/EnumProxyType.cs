using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Proxy.Enums
{
    public enum ProxyType
    {

        Any = 0,

        NonTransfer = 1,

        Governance = 2,

        Staking = 3,

        IdentityJudgement = 5,

        CancelProxy = 6,

        Auction = 7,
    }

    /// <summary>
    /// >> 79 - Variant[polkadot_runtime.ProxyType]
    /// </summary>
    public sealed class EnumProxyType : BaseEnum<ProxyType>
    {
    }
}
