using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship.Enums
{
    [DomainMapping(DomainMappingAttribute.PalletAuthorshipExt)]
    public enum Error
    {

        InvalidUncleParent = 0,

        UnclesAlreadySet = 1,

        TooManyUncles = 2,

        GenesisUncle = 3,

        TooHighUncle = 4,

        UncleAlreadyIncluded = 5,

        OldUncle = 6,
    }

    /// <summary>
    /// >> 483 - Variant[pallet_authorship.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
