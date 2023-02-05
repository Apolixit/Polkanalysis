using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public enum PoolState
    {

        Open = 0,

        Blocked = 1,

        Destroying = 2,
    }
}
