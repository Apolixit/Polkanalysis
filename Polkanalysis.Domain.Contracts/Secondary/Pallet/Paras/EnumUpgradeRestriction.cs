using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras
{
    public enum UpgradeRestriction
    {

        Present = 0,
    }

    /// <summary>
    /// >> 677 - Variant[polkadot_primitives.v2.UpgradeRestriction]
    /// </summary>
    public sealed class EnumUpgradeRestriction : BaseEnum<UpgradeRestriction>
    {
    }
}
