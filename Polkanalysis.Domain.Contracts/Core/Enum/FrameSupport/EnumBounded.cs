using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Enum.FrameSupport
{
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
