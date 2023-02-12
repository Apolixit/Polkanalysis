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
    public class AccountData
    {
        public U128 Free { get; set; } = new U128().With(BigInteger.Zero);
        public U128 Reserved { get; set; } = new U128().With(BigInteger.Zero);
        public U128 MiscFrozen { get; set; } = new U128().With(BigInteger.Zero);
        public U128 FeeFrozen { get; set; } = new U128().With(BigInteger.Zero);

    }
}
