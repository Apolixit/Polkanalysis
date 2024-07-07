using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Era
{
    internal class EraStackersDto
    {
        public required int EraId { get; set; }
        public required UserIdentityDto ValidatorAddress { get; set; }

        public double TotalStake { get; set; }
        public double OwnStake { get; set; }

        public IEnumerable<EraStakersNominatorsDto> EraNominatorsVote { get; set; } = Enumerable.Empty<EraStakersNominatorsDto>();
    }

    public class EraStakersNominatorsDto
    {
        public required UserIdentityDto NominatorAddress { get; set; }
        public double ValueStake { get; set; }
    }
}
