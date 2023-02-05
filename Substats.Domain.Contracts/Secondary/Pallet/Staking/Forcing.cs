using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public enum Forcing
    {

        NotForcing = 0,

        ForceNew = 1,

        ForceNone = 2,

        ForceAlways = 3,
    }
}
