using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Dto.Module
{
    public class ModuleEventsDto
    {
        public required string Name { get; set; }
        public required int Lookup { get; set; }
        public required string AttributesSumUp { get; set; }
        public string? Documentation { get; set; }
    }
}
