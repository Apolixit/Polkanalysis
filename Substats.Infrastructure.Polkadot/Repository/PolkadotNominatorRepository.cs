using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class PolkadotNominatorRepository : INominatorRepository
    {
        private readonly ISubstrateNodeRepository _substrateNodeRepository;

        public PolkadotNominatorRepository(ISubstrateNodeRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        public async Task<NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken)
        {
            //var res21 = await _substrateNodeRepository.Client.StakingStorage.Nominators(accountId32, cancellationToken);
            //var res22 = await _substrateNodeRepository.Client.StakingStorage.Payee(accountId32, cancellationToken);

            return null;
        }
    }
}
