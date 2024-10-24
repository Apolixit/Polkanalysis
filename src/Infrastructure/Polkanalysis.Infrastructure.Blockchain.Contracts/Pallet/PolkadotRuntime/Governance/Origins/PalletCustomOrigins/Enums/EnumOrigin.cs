using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.Governance.Origins.PalletCustomOrigins.Enums
{
    [DomainMapping("polkadot_runtime/governance/origins/pallet_custom_origins")]
    public enum Origin
    {
        StakingAdmin = 0,
        Treasurer = 1,
        FellowshipAdmin = 2,
        GeneralAdmin = 3,
        AuctionAdmin = 4,
        LeaseAdmin = 5,
        ReferendumCanceller = 6,
        ReferendumKiller = 7,
        SmallTipper = 8,
        BigTipper = 9,
        SmallSpender = 10,
        MediumSpender = 11,
        BigSpender = 12,
        WhitelistedCaller = 13
    }

    /// <summary>
    /// >> 14056 - Variant[polkadot_runtime.governance.origins.pallet_custom_origins.Origin]
    /// </summary>
    public sealed class EnumOrigin : BaseEnum<Origin>
    {
    }
}
