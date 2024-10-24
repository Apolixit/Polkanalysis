using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.Enum
{
    [DomainMapping("polkadot_primitives/v4")]
    public enum UpgradeRestriction
    {
        Present = 0
    }

    /// <summary>
    /// >> 15475 - Variant[polkadot_primitives.v4.UpgradeRestriction]
    /// </summary>
    public sealed class EnumUpgradeRestriction : BaseEnum<UpgradeRestriction>
    {
    }
}
