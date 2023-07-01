using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking.Enums
{
    public enum ConfigOp
    {

        Noop = 0,

        Set = 1,

        Remove = 2,
    }

    /// <summary>
    /// >> 210 - Variant[pallet_staking.pallet.pallet.ConfigOp]
    /// </summary>
    public sealed class EnumConfigOp : BaseEnumExt<ConfigOp, BaseVoid, Perbill, BaseVoid>
    {
    }
}
