using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums
{
    [DomainMapping("polkadot_primitives/v2")]
    public enum UpgradeGoAhead
    {

        Abort = 0,

        GoAhead = 1,
    }

    /// <summary>
    /// >> 676 - Variant[polkadot_primitives.v2.UpgradeGoAhead]
    /// </summary>
    public sealed class EnumUpgradeGoAhead : BaseEnum<UpgradeGoAhead>
    {
    }
}
