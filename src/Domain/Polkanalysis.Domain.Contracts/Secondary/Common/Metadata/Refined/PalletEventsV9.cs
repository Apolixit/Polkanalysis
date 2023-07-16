using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Refined
{
    public class PalletEventsV9
    {
        public string Name { get; set; }
        public uint[] Args { get; set; }
        public string[] Docs { get; set; }
    }
}
