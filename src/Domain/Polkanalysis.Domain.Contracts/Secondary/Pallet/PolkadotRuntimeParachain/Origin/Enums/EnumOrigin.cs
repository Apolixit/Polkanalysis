using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Origin.Enums
{
    public enum Origin
    {

        Parachain = 0,
    }

    /// <summary>
    /// >> 260 - Variant[polkadot_runtime_parachains.origin.pallet.Origin]
    /// </summary>
    public sealed class EnumOrigin : BaseEnumExt<Origin, Id>
    {
    }
}
