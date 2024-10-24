using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums
{
    [DomainMapping("pallet_preimage/pallet")]
    public enum Error
    {

        TooBig = 0,

        AlreadyNoted = 1,

        NotAuthorized = 2,

        NotNoted = 3,

        Requested = 4,

        NotRequested = 5,
    }

    /// <summary>
    /// >> 455 - Variant[pallet_preimage.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
