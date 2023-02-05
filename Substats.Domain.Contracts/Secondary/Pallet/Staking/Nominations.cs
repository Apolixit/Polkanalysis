using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class Nominations
    {
        public IEnumerable<SubstrateAccount> Targets { get; set; } = Enumerable.Empty<SubstrateAccount>();
        public uint SubmittedIn { get; set; }
        public bool Suppressed { get; set; }
    }
}
