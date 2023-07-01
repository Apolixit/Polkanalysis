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
        public IEnumerable<ModuleCallsDto> Calls { get; set; } = Enumerable.Empty<ModuleCallsDto>();
        public IEnumerable<ModuleEventsDto> Events { get; set; } = Enumerable.Empty<ModuleEventsDto>();
        public IEnumerable<ModuleStorageDto> Storage { get; set; } = Enumerable.Empty<ModuleStorageDto>();
        public IEnumerable<ModuleConstantsDto> Constants { get; set; } = Enumerable.Empty<ModuleConstantsDto>();
        public IEnumerable<ModuleErrorsDto> Errors { get; set; } = Enumerable.Empty<ModuleErrorsDto>();
    }
}
