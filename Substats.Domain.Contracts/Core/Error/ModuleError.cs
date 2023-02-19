using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Error
{
    public class ModuleError : BaseType
    {
        public U8 Index { get; set; }
        public U8[] Error { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            foreach (var v in Error) { result.AddRange(v.Encode()); };
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            // TODO
        }
    }
}
