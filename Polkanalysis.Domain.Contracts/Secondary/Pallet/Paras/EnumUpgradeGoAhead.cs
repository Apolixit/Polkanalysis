using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras
{
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
