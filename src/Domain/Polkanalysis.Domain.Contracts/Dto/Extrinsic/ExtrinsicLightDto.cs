using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Extrinsic
{
    public class ExtrinsicLightDto
    {
        public required string ExtrinsicId { get; set; }
        public required uint BlockNumber { get; set; }
        public required DateTime BlockDate { get; set; }
        public required LifetimeDto? Lifetime { get; set; }
        public required string Method { get; set; }
        public required string Event { get; set; }
        public string? AccountAddress { get; set; }
        public bool IsSigned { get; set; }
        public string Status { get; set; } = string.Empty;
        public double? Fees { get; set; }
    }
}
