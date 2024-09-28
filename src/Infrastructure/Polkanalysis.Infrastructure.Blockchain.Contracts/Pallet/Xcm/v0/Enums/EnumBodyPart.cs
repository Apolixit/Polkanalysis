using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums
{
    [DomainMapping("xcm/v0/junction")]
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
