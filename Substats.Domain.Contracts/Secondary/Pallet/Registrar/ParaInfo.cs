using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Registrar
{
    public class ParaInfo
    {
        public required SubstrateAccount Manager { get; set; }
        public U128 Deposit { get; set; } = new U128().With(BigInteger.Zero);
        public Bool Locked { get; set; }
    }
}
