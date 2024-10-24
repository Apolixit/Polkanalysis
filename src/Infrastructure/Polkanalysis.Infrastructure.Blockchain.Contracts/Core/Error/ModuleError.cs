using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error
{
    public class ModuleError : BaseType
    {
        public ModuleError() { }

        public ModuleError(U8 index, U8 error)
        {
            Create(index, [error, new U8(0), new U8(0), new U8(0)]);
        }

        public ModuleError(U8 index, U8[] error)
        {
            Create(index, error);
        }

        public void Create(U8 index, U8[] error)
        {
            Index = index;
            Error = new NameableSize4(error.Select(x => x.Bytes[0]).ToArray());

            TypeSize = Index.TypeSize + Error.TypeSize;
        }

        public U8 Index { get; set; }
        public NameableSize4 Error { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Error.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new U8();
            Index.Decode(byteArray, ref p);

            Error = new NameableSize4();
            Error.Decode(byteArray, ref p);

            TypeSize = p - start;
        }
    }
}
