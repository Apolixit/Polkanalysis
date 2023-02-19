using Ajuna.NetApi.Model.Types.Base;
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

    public sealed class EnumDigestItem : BaseEnumExt<DigestItem, BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>, BaseVoid, BaseVoid, BaseVoid, BaseTuple<Polkadot.NetApiExt.Generated.Types.Base.Arr4U8, BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>, BaseTuple<Polkadot.NetApiExt.Generated.Types.Base.Arr4U8, BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>, BaseTuple<Polkadot.NetApiExt.Generated.Types.Base.Arr4U8, BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>, BaseVoid, BaseVoid>
    {
    }
}
