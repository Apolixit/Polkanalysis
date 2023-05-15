using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Display;

namespace Polkanalysis.Domain.Contracts.Core.Multi
{
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
    public sealed class EnumMultiAddress : BaseEnumExt<MultiAddress, SubstrateAccount, BaseCom<BaseTuple>, BaseVec<U8>, FlexibleNameable, FlexibleNameable>
    {
    }
}
