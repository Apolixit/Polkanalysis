using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances
{
    public class BalanceLock : BaseType
    {
        public NameableSize8 Id { get; set; }
        public U128 Amount { get; set; } = new U128();
        public EnumReasons Reasons { get; set; }

        public void Create(NameableSize8 id, U128 amount, EnumReasons reasons)
        {
            this.Id = id;
            this.Amount = amount;
            this.Reasons = reasons;

            Bytes = Encode();
            TypeSize = Id.TypeSize + Amount.TypeSize + Reasons.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Amount.Encode());
            result.AddRange(Reasons.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new NameableSize8();
            Id.Decode(byteArray, ref p);
            Amount = new U128();
            Amount.Decode(byteArray, ref p);
            Reasons = new EnumReasons();
            Reasons.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
