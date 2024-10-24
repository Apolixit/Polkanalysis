using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
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
        Core.DispatchInfo.EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, Core.DispatchInfo.EnumRawOrigin,
        Core.DispatchInfo.EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        Collective.Enums.EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid,
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, 
        Xcm.Enums.EnumOrigin>
    {
    }
}
