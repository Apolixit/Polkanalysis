using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums
{
    [DomainMapping("polkadot_runtime_common/auctions/pallet")]
    public enum Error
    {

        AuctionInProgress = 0,

        LeasePeriodInPast = 1,

        ParaNotRegistered = 2,

        NotCurrentAuction = 3,

        NotAuction = 4,

        AuctionEnded = 5,

        AlreadyLeasedOut = 6,
    }

    /// <summary>
    /// >> 711 - Variant[polkadot_runtime_common.auctions.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
