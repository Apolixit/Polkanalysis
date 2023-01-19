using Substats.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class NominatorRepositoryDirectAccess : INominatorRepository
    {
        private readonly ISubstrateNodeRepository _substrateNodeRepository;

        public NominatorRepositoryDirectAccess(ISubstrateNodeRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }
    }
}
