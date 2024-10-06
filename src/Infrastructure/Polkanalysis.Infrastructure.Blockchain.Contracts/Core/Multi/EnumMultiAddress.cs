using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Multi
{
    [DomainMapping("sp_runtime/multiaddress")]
    public enum MultiAddress
    {

        Id = 0,

        Index = 1,

        Raw = 2,

        Address32 = 3,

        Address20 = 4,
    }

    /// <summary>
    /// >> 197 - Variant[sp_runtime.multiaddress.MultiAddress]
    /// </summary>
    public sealed class EnumMultiAddress : BaseEnumExt<MultiAddress, SubstrateAccount, BaseCom<BaseTuple>, BaseVec<U8>, NameableSize32, NameableSize20>
    {
    }
}
