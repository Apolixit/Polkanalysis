using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Secondary.Pallet.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class Registration
    {
        public required IdentityInfo Info { get; set; } = new IdentityInfo();
        public required U128 Deposit { get; set; } = new U128().With(BigInteger.Zero);
        public required EnumJudgement Judgement { get; set; }
    }
}
