using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum BodyPart
    {

        Voice = 0,

        Members = 1,

        Fraction = 2,

        AtLeastProportion = 3,

        MoreThanProportion = 4,
    }

    /// <summary>
    /// >> 129 - Variant[xcm.v0.junction.BodyPart]
    /// </summary>
    public sealed class EnumBodyPart : BaseEnumExt<BodyPart, BaseVoid, BaseCom<U32>, BaseTuple<BaseCom<U32>, BaseCom<U32>>, BaseTuple<BaseCom<U32>, BaseCom<U32>>, BaseTuple<BaseCom<U32>, BaseCom<U32>>>
    {
    }
}
