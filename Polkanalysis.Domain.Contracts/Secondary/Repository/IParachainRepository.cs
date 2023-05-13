using Polkanalysis.Domain.Contracts.Dto.Parachain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IParachainRepository
    {
        public Task<IEnumerable<ParachainLightDto>> GetParachainsAsync(CancellationToken cancellationToken);
        public Task<ParachainDto> GetParachainDetailAsync(uint parachainId, CancellationToken cancellationToken);
    }
}
