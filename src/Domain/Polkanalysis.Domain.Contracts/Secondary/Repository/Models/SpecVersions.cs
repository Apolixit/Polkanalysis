using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository.Models
{
    public class SpecVersions
    {
        public uint SpecVersion { get; set; }
        public uint BlockStart { get; set; }
        public uint? BlockEnd { get; set; }
        public string Metadata { get; set; } = string.Empty;
    }
}
