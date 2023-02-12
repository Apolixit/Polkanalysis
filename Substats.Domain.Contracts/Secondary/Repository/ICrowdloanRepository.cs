using Substats.Domain.Contracts.Dto.Parachain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Repository
{
    public interface ICrowdloanRepository
    {
        // Slots storage > leases ?

        public Task<CrowdloanDto> GetCrowdloanDetailAsync(string crowdloanId, CancellationToken cancellationToken);
    }
}
