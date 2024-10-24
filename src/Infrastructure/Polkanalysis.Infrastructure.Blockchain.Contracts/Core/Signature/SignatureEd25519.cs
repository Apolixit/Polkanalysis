using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature
{
    public class SignatureEd25519 : Signature
    {
        public override KeyType Key => KeyType.Ed25519;

        //public SignatureEd25519() : this(new U8[] { }) { }
        public SignatureEd25519() : base() { }
        public SignatureEd25519(U8[] value) : base(value)
        {
        }

        public SignatureEd25519(string hexa) : base(Utils.HexToByteArray(hexa).Select(x => new U8(x)).ToArray())
        {
        }
    }
}
