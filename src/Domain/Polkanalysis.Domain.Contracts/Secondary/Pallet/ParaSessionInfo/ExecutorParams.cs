using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.ParaSessionInfo
{
    public class ExecutorParams : BaseType
    {
        public BaseVec<Enums.EnumExecutorParam> Value { get; set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            throw new NotImplementedException();
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
    }
}
