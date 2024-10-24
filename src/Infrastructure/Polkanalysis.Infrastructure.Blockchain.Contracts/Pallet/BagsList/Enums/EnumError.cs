using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.BagsList.Enums
{
    [DomainMapping("pallet_bags_list/pallet")]
    public enum Error
    {

        List = 0,
    }

    /// <summary>
    /// >> 615 - Variant[pallet_bags_list.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnumExt<Error, EnumListError>
    {
    }
}
