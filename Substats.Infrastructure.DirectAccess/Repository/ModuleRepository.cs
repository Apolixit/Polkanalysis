using Substats.Domain.Contracts.Dto.Module;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ICurrentMetaData _currentMetaData;

        public ModuleRepository(ICurrentMetaData currentMetaData)
        {
            _currentMetaData = currentMetaData;
        }

        public Task<ModuleDetailDto> GetModuleDetailAsync(string moduleId, CancellationToken cancellationToken)
        {
            throw new ArgumentNullException("todo");
        }

        public Task<int> GetNbCallAsync(string moduleId, DateTime from, DateTime to, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
