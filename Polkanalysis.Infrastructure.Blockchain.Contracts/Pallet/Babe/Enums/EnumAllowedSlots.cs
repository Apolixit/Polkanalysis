using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums
{
    [DomainMapping("sp_consensus_babe")]
    public enum AllowedSlots
    {

        PrimarySlots = 0,

        PrimaryAndSecondaryPlainSlots = 1,

        PrimaryAndSecondaryVRFSlots = 2,
    }

    public sealed class EnumAllowedSlots : BaseEnum<AllowedSlots>
    {
    }
}
