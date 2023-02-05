using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class Registration
    {
        public required IdentityInfo Info { get; set; } = new IdentityInfo();
        public required BigInteger Deposit { get; set; } = BigInteger.Zero;
        public required EnumJudgement Judgement { get; set; }
    }
}
