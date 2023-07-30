using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion
{
    public class SpecVersionDto
    {
        public uint SpecVersion { get; set; }
        public uint BlockStart { get; set; }
        public string BlockStartHash { get; set; } = string.Empty;
        public uint? BlockEnd { get; set; }
        public string? BlockEndHash { get; set; }
        public uint MetadataVersion { get; set; }
    }
}
