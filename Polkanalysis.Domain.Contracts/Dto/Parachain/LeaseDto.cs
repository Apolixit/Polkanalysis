using Polkanalysis.Domain.Contracts.Dto.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain
{
    public class LeaseDto
    {
        public uint LeaseStart { get; set; }
        public DateTime LeaseDateStart { get; set; }
        public uint LeaseEnd { get; set; }
        public uint LeaseDateEnd { get; set; }
        public required BlockLightDto BlockStart { get; set; }
        public required BlockLightDto BlockEnd { get; set; }
    }
}
