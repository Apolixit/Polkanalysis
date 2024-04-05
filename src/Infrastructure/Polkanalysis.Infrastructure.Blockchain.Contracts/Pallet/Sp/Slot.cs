using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Sp
{
    public class Slot : BaseType
    {
        public Slot() { }

        public Slot(U64 value)
        {
            Value = value;
        }

        /// <summary>
        /// >> value
        /// </summary>
        public U64 Value { get; set; }

        public override string TypeName()
        {
            return "Slot";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            throw new NotImplementedException();
        }
    }
}
