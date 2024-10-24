using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ConvictionVoting.Enums
{
    [DomainMapping("pallet_conviction_voting/pallet")]
    public enum Error
    {
        NotOngoing = 0,
        NotVoter = 1,
        NoPermission = 2,
        NoPermissionYet = 3,
        AlreadyDelegating = 4,
        AlreadyVoting = 5,
        InsufficientFunds = 6,
        NotDelegating = 7,
        Nonsense = 8,
        MaxVotesReached = 9,
        ClassNeeded = 10,
        BadClass = 11
    }

    /// <summary>
    /// >> 14512 - Variant[pallet_conviction_voting.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
