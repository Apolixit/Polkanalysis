using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("pallet_xcm/pallet")]
    public enum Error
    {

        Unreachable = 0,

        SendFailure = 1,

        Filtered = 2,

        UnweighableMessage = 3,

        DestinationNotInvertible = 4,

        Empty = 5,

        CannotReanchor = 6,

        TooManyAssets = 7,

        InvalidOrigin = 8,

        BadVersion = 9,

        BadLocation = 10,

        NoSubscription = 11,

        AlreadySubscribed = 12,
    }

    /// <summary>
    /// >> 726 - Variant[pallet_xcm.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
