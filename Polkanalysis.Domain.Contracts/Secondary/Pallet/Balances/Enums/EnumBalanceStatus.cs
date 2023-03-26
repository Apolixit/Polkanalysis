using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums
{
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
