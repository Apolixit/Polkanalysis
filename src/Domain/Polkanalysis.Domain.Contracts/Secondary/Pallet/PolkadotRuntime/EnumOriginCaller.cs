using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Origin.Enums;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime
{
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
    public sealed class EnumOriginCaller : BaseEnumExt<OriginCaller, Core.DispatchInfo.EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Collective.Enums.EnumRawOrigin, Collective.Enums.EnumRawOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, EnumOrigin, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Xcm.Enums.EnumOrigin>
    {
    }
}
