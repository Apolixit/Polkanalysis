using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core
{
    public class SubstrateAccount : BaseType
    {
        // From AccountId32
        public string Value { get; set; } = string.Empty;
        public byte[] Bytes { get; set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            throw new NotImplementedException();
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
