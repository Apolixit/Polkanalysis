using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum
{
    [DomainMapping("frame_support/traits/preimages")]
    public enum Bounded
    {

        Legacy = 0,

        Inline = 1,

        Lookup = 2,
    }

    /// <summary>
    /// >> 180 - Variant[frame_support.traits.preimages.Bounded]
    /// </summary>
    public sealed class EnumBounded : BaseEnumExt<Bounded,
        Hash,
        BaseVec<U8>,
        BaseTuple<Hash, U32>>
    {
    }
}
