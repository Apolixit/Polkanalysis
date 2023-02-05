using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class SuperOfResult
    {
        public required SubstrateAccount Account { get; set; }
        public required string Raw { get; set; }
    }
}

