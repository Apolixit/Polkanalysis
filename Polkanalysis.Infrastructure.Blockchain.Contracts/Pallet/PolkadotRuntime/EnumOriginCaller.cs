using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Origin.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime
{
    [DomainMapping("polkadot_runtime")]
    public enum OriginCaller
    {

        system = 0,

        Council = 15,

        TechnicalCommittee = 16,

        ParachainsOrigin = 50,

        XcmPallet = 99,

        Void = 5,
    }

    /// <summary>
    /// >> 256 - Variant[polkadot_runtime.OriginCaller]
    /// </summary>
    public sealed class EnumOriginCaller : BaseEnumExt<OriginCaller,
        Domain.Contracts.Core.DispatchInfo.EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, EnumRawOrigin, 
        EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums.EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid,
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        Xcm.Enums.EnumOrigin>
    {
    }
}
