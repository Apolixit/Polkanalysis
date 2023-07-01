using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core.Public
{
    public class PublicSr25519 : Public
    {
        public override KeyType Key => KeyType.Sr25519;

        public PublicSr25519() : this(new U8[] { }) {}

        public PublicSr25519(U8[] value) : base(value)
        {
            Bytes = Encode();
            TypeSize = Value.Length;
        }

        public PublicSr25519(string hex) : this(Utils.HexToByteArray(hex).Select(x => new U8(x)).ToArray())
        {
        }
    }
}
