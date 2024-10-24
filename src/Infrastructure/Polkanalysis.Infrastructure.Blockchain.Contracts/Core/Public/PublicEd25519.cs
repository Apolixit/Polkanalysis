using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public
{
    public class PublicEd25519 : Public
    {
        public override KeyType Key => KeyType.Ed25519;

        //public PublicEd25519() : this(new U8[] { }) { }
        public PublicEd25519() : base() { }

        public PublicEd25519(U8[] value) : base(value)
        {
        }

        public PublicEd25519(string hexa) : base(Utils.HexToByteArray(hexa).Select(x => new U8(x)).ToArray())
        {
        }
    }
}
