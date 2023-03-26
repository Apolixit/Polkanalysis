using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Public
{
    public class PublicEcdsa : Public
    {
        public override KeyType Key => KeyType.Sr25519;

        public PublicEcdsa() : this(new U8[] { }) { }
        public PublicEcdsa(U8[] value) : base(value)
        {
        }

        public PublicEcdsa(string hex) : base(Utils.HexToByteArray(hex).Select(x => new U8(x)).ToArray())
        {
        }
    }
}
