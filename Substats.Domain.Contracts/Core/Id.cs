using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core
{
    /// <summary>
    /// Model.polkadot_parachain.primitives.Id
    /// </summary>
    public class Id : BaseType
    {
        public Id() { }
        public Id(uint value)
        {
            Create(BitConverter.GetBytes(value));
        }

        public U32 Value { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
