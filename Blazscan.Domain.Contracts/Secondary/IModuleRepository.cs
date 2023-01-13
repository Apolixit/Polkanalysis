using Blazscan.Domain.Contracts.Dto.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Secondary
{
    public interface IModuleRepository
    {
        /// <summary>
        /// Display the module detail
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public Task<ModuleDetailDto> GetModuleDetailAsync(string moduleId, CancellationToken cancellationToken);

        /// <summary>
        /// Number of call to this module between two date
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> GetNbCallAsync(string moduleId, DateTime from, DateTime to, CancellationToken cancellationToken);
    }
}
