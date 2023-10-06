using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Sp
{
    public class Slot : BaseType
    {
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Value { get; set; }

        public override System.String TypeName()
        {
            return "Slot";
        }

        public override System.Byte[] Encode()
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
