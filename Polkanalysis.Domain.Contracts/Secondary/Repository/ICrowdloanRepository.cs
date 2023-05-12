using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface ICrowdloanRepository
    {
        // Slots storage > leases ?

        public Task<IEnumerable<CrowdloanListDto>> GetCrowdloansAsync(CancellationToken cancellationToken);
        public Task<CrowdloanDto> GetCrowdloanDetailAsync(uint crowdloanId, CancellationToken cancellationToken);
    }
}
