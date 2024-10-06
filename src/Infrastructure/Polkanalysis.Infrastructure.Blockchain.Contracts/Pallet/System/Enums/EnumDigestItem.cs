using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums
{
    [DomainMapping("sp_runtime/generic/digest")]
    public enum DigestItem
    {

        PreRuntime = 6,

        Consensus = 4,

        Seal = 5,

        Other = 0,

        RuntimeEnvironmentUpdated = 8,
    }

    public sealed class EnumDigestItem : BaseEnumExt<DigestItem, BaseVec<U8>, BaseVoid, BaseVoid, BaseVoid, BaseTuple<NameableSize4, BaseVec<U8>>, BaseTuple<NameableSize4, BaseVec<U8>>, BaseTuple<NameableSize4, BaseVec<U8>>, BaseVoid, BaseVoid>
    {
    }
}
