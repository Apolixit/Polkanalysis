using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship.Enums
{
    [DomainMapping("pallet_authorship")]
    public enum UncleEntryItem
    {

        InclusionHeight = 0,

        Uncle = 1,
    }

    /// <summary>
    /// >> 481 - Variant[pallet_authorship.UncleEntryItem]
    /// </summary>
    public sealed class EnumUncleEntryItem : BaseEnumExt<UncleEntryItem, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Hash, BaseOpt<SubstrateAccount>>>
    {
    }
}
