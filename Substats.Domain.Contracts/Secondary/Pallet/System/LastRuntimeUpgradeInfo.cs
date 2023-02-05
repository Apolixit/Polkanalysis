using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class LastRuntimeUpgradeInfo
    {
        public uint SpecVersion { get; set; }
        public string SpecName { get; set; }
    }
}
