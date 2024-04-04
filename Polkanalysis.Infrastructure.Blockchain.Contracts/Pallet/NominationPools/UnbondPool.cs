using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools
{
    public class UnbondPool : BaseType
    {
        public U128 Points { get; set; }
        public U128 Balance { get; set; }

        public UnbondPool() { }

        public UnbondPool(U128 points, U128 balance)
        {
            Create(points, balance);
        }

        public void Create(U128 points, U128 balance)
        {
            Points = points;
            Balance = balance;

            Bytes = Encode();
            TypeSize = points.TypeSize + balance.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Points.Encode());
            result.AddRange(Balance.Encode());
            return result.ToArray();
        }
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Points = new U128();
            Points.Decode(byteArray, ref p);
            Balance = new U128();
            Balance.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
