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
    public class ReserveData
    {
        public required string Id { get; set; }
        public U128 Amount { get; set; } = new U128().With(BigInteger.Zero);
    }
}
