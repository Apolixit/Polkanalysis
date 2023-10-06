using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v4
{
    public enum PvfExecTimeoutKind
    {
        Backing = 0,
        Approval = 1
    }

    /// <summary>
    /// >> 14210 - Variant[polkadot_primitives.v4.PvfExecTimeoutKind]
    /// </summary>
    public sealed class EnumPvfExecTimeoutKind : BaseEnum<PvfExecTimeoutKind>
    {
    }
}
