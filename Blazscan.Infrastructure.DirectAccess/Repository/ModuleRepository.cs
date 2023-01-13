using Blazscan.Domain.Contracts.Dto.Module;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Repository
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
