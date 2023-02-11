using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Session
{
    public class SessionKeys
    {
        public Public Grandpa { get; set; }
        public Public Babe { get; set; }
        public Public ImOnline { get; set; }
        public Public ParaValidator { get; set; }
        public Public ParaAssignment { get; set; }
        public Public AuthorityDiscovery { get; set; }
    }
}
