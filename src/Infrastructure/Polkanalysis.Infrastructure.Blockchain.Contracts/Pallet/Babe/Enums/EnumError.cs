using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums
{
    [DomainMapping("pallet_babe/pallet")]
    public enum Error
    {

        InvalidEquivocationProof = 0,

        InvalidKeyOwnershipProof = 1,

        DuplicateOffenceReport = 2,

        //InvalidConfiguration = 3,
    }

    /// <summary>
    /// >> 467 - Variant[pallet_babe.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
