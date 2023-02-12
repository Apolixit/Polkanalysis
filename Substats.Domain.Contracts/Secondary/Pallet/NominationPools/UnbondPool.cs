using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class UnbondPool : BaseType
    {
        public U128 Points { get; set; }
        public U128 Balance { get; set; }

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
            Points = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Points.Decode(byteArray, ref p);
            Balance = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Balance.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
