using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4
{
    [DomainMapping("polkadot_primitives/v4")]
    public enum PvfPrepTimeoutKind
    {
        Precheck = 0,
        Lenient = 1
    }

    /// <summary>
    /// >> 14209 - Variant[polkadot_primitives.v4.PvfPrepTimeoutKind]
    /// </summary>
    public sealed class EnumPvfPrepTimeoutKind : BaseEnum<PvfPrepTimeoutKind>
    {
    }
}
