using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances
{
    public class ReserveData : BaseType
    {
        public ReserveData() { }

        public ReserveData(FlexibleNameable id, U128 amount)
        {
            Create(id, amount);
        }

        public void Create(FlexibleNameable id, U128 amount)
        {
            Id = id;
            Amount = amount;

            Bytes = Encode();
            TypeSize = Id.TypeSize + Amount.TypeSize;
        }

        public FlexibleNameable Id { get; set; }
        public U128 Amount { get; set; } = new U128();

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Amount.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new FlexibleNameable();
            Id.Decode(byteArray, ref p);
            Amount = new U128();
            Amount.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
