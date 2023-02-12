using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Balances
{
    public class BalanceLock
    {
        public required string Id { get; set; }
        public U128 Amount { get; set; } = new U128().With(BigInteger.Zero);
        public required ReasonType Reason { get; set; }

        public enum ReasonType
        {
            Fee = 0,
            Misc = 1,
            All = 2,
        }
    }
}
