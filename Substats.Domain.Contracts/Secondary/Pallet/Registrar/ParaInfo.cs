using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Registrar
{
    public class ParaInfo
    {
        public required SubstrateAccount Manager { get; set; }
        public BigInteger Deposit { get; set; } = BigInteger.Zero;
        public bool Locked { get; set; }
    }
}
