using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ImOnline.Enums
{
    [DomainMapping("pallet_im_online/pallet")]
    public enum Error
    {

        InvalidKey = 0,

        DuplicatedHeartbeat = 1,
    }

    /// <summary>
    /// >> 526 - Variant[pallet_im_online.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
