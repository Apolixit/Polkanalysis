using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class PoolRoles
    {
        public SubstrateAccount? Depositor { get; set; }
        public SubstrateAccount? Root { get; set; }
        public SubstrateAccount? Nominator { get; set; }
        public SubstrateAccount? StateToggler { get; set; }

    }
}
