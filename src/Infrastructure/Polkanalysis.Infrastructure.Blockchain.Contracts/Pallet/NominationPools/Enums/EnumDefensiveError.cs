using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    [DomainMapping("pallet_nomination_pools/pallet")]
    public enum DefensiveError
    {

        NotEnoughSpaceInUnbondPool = 0,

        PoolNotFound = 1,

        RewardPoolNotFound = 2,

        SubPoolsNotFound = 3,

        BondedStashKilledPrematurely = 4,
    }

    /// <summary>
    /// >> 633 - Variant[pallet_nomination_pools.pallet.DefensiveError]
    /// </summary>
    public sealed class EnumDefensiveError : BaseEnum<DefensiveError>
    {
    }
}
