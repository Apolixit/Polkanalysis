using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Module
{
    public class ModuleDetailDto
    {
        public required ModuleInfoDto Information { get; set; }
        public IEnumerable<ModuleCallsDto>? Calls { get; set; }
        public IEnumerable<ModuleEventsDto>? Events { get; set; }
        public IEnumerable<ModuleStorageDto>? Storage { get; set; }
        public IEnumerable<ModuleConstantsDto>? Constants { get; set; }
        public IEnumerable<ModuleErrorsDto>? Errors { get; set; }
    }
}
