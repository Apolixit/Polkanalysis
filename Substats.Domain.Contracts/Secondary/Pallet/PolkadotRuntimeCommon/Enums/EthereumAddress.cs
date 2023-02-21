using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeCommon.Enums
{
    public class EthereumAddress : BaseType
    {
        public Nameable Value { get; set; }
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Nameable();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
