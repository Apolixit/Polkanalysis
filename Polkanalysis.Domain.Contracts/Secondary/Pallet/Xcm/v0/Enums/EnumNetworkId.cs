using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums
{
    public enum NetworkId
    {

        Any = 0,

        Named = 1,

        Polkadot = 2,

        Kusama = 3,
    }

    /// <summary>
    /// >> 126 - Variant[xcm.v0.junction.NetworkId]
    /// </summary>
    public sealed class EnumNetworkId : BaseEnumExt<NetworkId, BaseVoid, FlexibleNameable, BaseVoid, BaseVoid>
    {
    }
}
