using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System.Enums
{
    public enum DigestItem
    {

        PreRuntime = 6,

        Consensus = 4,

        Seal = 5,

        Other = 0,

        RuntimeEnvironmentUpdated = 8,
    }

    public sealed class EnumDigestItem : BaseEnumExt<DigestItem, BaseVec<U8>, BaseVoid, BaseVoid, BaseVoid, BaseTuple<Nameable, BaseVec<U8>>, BaseTuple<Nameable, BaseVec<U8>>, BaseTuple<Nameable, BaseVec<U8>>, BaseVoid, BaseVoid>
    {
    }
}
