using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Display;

namespace Substats.Domain.Contracts.Core.Multi
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
    public sealed class EnumMultiAddress : BaseEnumExt<MultiAddress, SubstrateAccount, BaseCom<BaseTuple>, BaseVec<U8>, Nameable, Nameable>
    {
    }
}
