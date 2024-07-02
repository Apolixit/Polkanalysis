using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Search
{
    public class EventsResultDto
    {
        public uint BlockId { get; set; }
        public DateTime BlockDate { get; set; }
        public uint EventId { get; set; }
        public required string PalletName { get; set; }
        public required string EventName { get; set; }
        public List<ContextParametersDto> ContextParameters { get; set; } = new List<ContextParametersDto>();

    }

    public class ContextParametersDto
    {
        public required string Name { get; set; }
        public required string FilterType { get; set; }
        public required object? Value { get; set; }
    }
}
