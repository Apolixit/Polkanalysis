using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class ValidatorPrefs : BaseType
    {
        public BaseCom<Perbill> Commission { get; set; }
        public Bool Blocked { get; set; }

        public ValidatorPrefs() { }

        public ValidatorPrefs(BaseCom<Perbill> commission, Bool blocked)
        {
            Commission = commission;
            Blocked = blocked;
        }

        public void Create(BaseCom<Perbill> commission, Bool blocked)
        {
            Commission = commission;
            Blocked = blocked;

            Bytes = Encode();
            TypeSize = Commission.TypeSize + Blocked.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Commission.Encode());
            result.AddRange(Blocked.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Commission = new BaseCom<Perbill>();
            Commission.Decode(byteArray, ref p);
            Blocked = new Bool();
            Blocked.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
