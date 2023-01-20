using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary
{
    public interface INominatorRepository
    {
        public Task <NominatorDto> GetNominatorDetailAsync(string nominatorAddress, CancellationToken cancellationToken);
    }
}
