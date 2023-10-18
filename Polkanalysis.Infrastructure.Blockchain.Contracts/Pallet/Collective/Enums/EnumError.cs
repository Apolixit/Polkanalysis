using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums
{
    public enum Error
    {

        NotMember = 0,

        DuplicateProposal = 1,

        ProposalMissing = 2,

        WrongIndex = 3,

        DuplicateVote = 4,

        AlreadyInitialized = 5,

        TooEarly = 6,

        TooManyProposals = 7,

        WrongProposalWeight = 8,

        WrongProposalLength = 9,
    }

    /// <summary>
    /// >> 548 - Variant[pallet_collective.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
