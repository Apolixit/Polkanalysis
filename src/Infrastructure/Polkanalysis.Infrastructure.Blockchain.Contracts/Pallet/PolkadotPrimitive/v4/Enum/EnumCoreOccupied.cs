using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.Enum
{
    [DomainMapping("polkadot_primitives/v4")]
    public enum CoreOccupied
    {
        Parathread = 0,
        Parachain = 1
    }

    /// <summary>
    /// >> 15459 - Variant[polkadot_primitives.v4.CoreOccupied]
    /// </summary>
    public sealed class EnumCoreOccupied : BaseEnumExt<CoreOccupied, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.ParathreadEntry, BaseVoid>
    {
    }
}
