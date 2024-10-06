using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature
{
    public class SignatureEcdsa : Signature
    {
        public override KeyType Key => KeyType.Sr25519;

        //public SignatureEcdsa() : this(new U8[] { }) { }
        public SignatureEcdsa() : base() { }
        public SignatureEcdsa(U8[] value) : base(value)
        {
        }

        public SignatureEcdsa(string hex) : base(Utils.HexToByteArray(hex).Select(x => new U8(x)).ToArray())
        {
        }
    }
}
