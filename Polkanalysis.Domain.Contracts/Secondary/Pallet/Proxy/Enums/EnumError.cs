using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Proxy.Enums
{
    public enum Error
    {

        TooMany = 0,

        NotFound = 1,

        NotProxy = 2,

        Unproxyable = 3,

        Duplicate = 4,

        NoPermission = 5,

        Unannounced = 6,

        NoSelfProxy = 7,
    }

    /// <summary>
    /// >> 586 - Variant[pallet_proxy.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
