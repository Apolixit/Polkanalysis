using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Dto.Module
{
    public class ModuleConstantsDto
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Value { get; set; }
        public string? Documentation { get; set; }
    }
}
