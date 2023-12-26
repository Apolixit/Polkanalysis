using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums
{
    [DomainMapping("sp_consensus_babe/digests")]
    public enum NextConfigDescriptor
    {

        V1 = 1,
    }

    public sealed class EnumNextConfigDescriptor : BaseEnumExt<NextConfigDescriptor, BaseVoid, BaseTuple<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64,
        Substrate.NetApi.Model.Types.Primitive.U64>,
        EnumAllowedSlots>>
    {
    }
}
