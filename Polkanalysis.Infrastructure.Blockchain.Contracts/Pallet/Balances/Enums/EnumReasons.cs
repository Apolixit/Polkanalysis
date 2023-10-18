using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums
{
    public enum Reasons
    {

        Fee = 0,

        Misc = 1,

        All = 2,
    }

    /// <summary>
    /// >> 472 - Variant[pallet_balances.Reasons]
    /// </summary>
    public sealed class EnumReasons : BaseEnum<Reasons>
    {
    }
}
