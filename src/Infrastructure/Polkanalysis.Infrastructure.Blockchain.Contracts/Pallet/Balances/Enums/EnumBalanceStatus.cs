using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums
{
    [DomainMapping("frame_support/traits/tokens/misc")]
    public enum BalanceStatus
    {

        Free = 0,

        Reserved = 1,
    }

    /// <summary>
    /// >> 37 - Variant[frame_support.traits.tokens.misc.BalanceStatus]
    /// </summary>
    public sealed class EnumBalanceStatus : BaseEnum<BalanceStatus>
    {
    }
}
