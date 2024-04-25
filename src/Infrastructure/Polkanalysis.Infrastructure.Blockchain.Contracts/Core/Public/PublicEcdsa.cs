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
    public class PublicEcdsa : Public
    {
        public override KeyType Key => KeyType.Sr25519;

        public override int TypeSize
        {
            get
            {
                return 33;
            }
        }

        public PublicEcdsa() : base() { }
        public PublicEcdsa(U8[] value) : base(value)
        {
        }

        public PublicEcdsa(string hex) : base(Utils.HexToByteArray(hex).Select(x => new U8(x)).ToArray())
        {
        }
    }
}
