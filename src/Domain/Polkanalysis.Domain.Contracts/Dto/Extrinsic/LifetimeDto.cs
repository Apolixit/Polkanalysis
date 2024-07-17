using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Extrinsic
{
    public class LifetimeDto
    {
        public uint? FromBlock { get; set; }
        public uint? ToBlock { get; set; }
        public bool IsImmortal { get; set; }
    }
}
