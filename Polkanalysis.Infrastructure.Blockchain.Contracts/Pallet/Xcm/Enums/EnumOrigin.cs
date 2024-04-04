using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("pallet_xcm/pallet")]
    public enum Origin
    {

        Xcm = 0,

        Response = 1,
    }

    /// <summary>
    /// >> 261 - Variant[pallet_xcm.pallet.Origin]
    /// </summary>
    public sealed class EnumOrigin : BaseEnumExt<Origin, MultiLocation, MultiLocation>
    {
    }
}
