using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Module
{
    public class SpecVersionDto
    {
        public int AuthoringVersion { get; set; }
        public string ImplName { get; set; } = string.Empty;
        public uint ImplVersion { get; set; }
        public string SpecName { get; set; } = string.Empty;
        public uint SpecVersion { get; set; }
        public uint TransactionVersion { get; set; }
    }
}
