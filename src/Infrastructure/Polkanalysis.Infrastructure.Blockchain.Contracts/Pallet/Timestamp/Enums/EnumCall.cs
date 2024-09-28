using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums
{
    [DomainMapping("pallet_timestamp/pallet")]
    public enum Call
    {
        set = 0
    }

    /// <summary>
    /// >> 14815 - Variant[pallet_timestamp.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseCom<U64>>
    {
    }
}
