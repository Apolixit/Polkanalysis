using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Module
{
    public class ModuleEventsDto
    {
        public required string Name { get; set; }
        public required int Lookup { get; set; }
        public IEnumerable<TypeFieldDto>? Arguments { get; set; }
        public string? Documentation { get; set; }
        public string SumUpArguments()
        {
            string sumUp = string.Empty;
            if(Arguments != null)
            {
                sumUp = $"[{string.Join(", ", Arguments.Select(a => a.Name))}]";
            }

            return sumUp;
        }
    }
}
