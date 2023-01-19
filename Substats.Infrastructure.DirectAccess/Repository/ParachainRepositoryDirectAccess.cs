using Substats.Domain.Contracts.Dto;
using Substats.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class ParachainRepositoryDirectAccess : IParachainRepository
    {
        private readonly ISubstrateNodeRepository _substrateNodeRepository;

        public ParachainRepositoryDirectAccess(ISubstrateNodeRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        public async Task<ParachainDto> GetParachainDetailAsync(string parachainId, CancellationToken cancellationToken)
        {
            var res24 = await _substrateNodeRepository.Client.ParasStorage.Parachains(cancellationToken);

            return null;
        }
    }
}
