using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9
{
    public class PalletConstantMetadataV9 : BaseType
    {
        public Str ConstantName { get; private set; }

        public Str ConstantType { get; private set; }

        public ByteGetter ConstantValue { get; private set; }

        public BaseVec<Str> Documentation { get; private set; }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            int num = p;
            ConstantName = new Str();
            ConstantName.Decode(byteArray, ref p);
            ConstantType = new Str();
            ConstantType.Decode(byteArray, ref p);
            ConstantValue = new ByteGetter();
            ConstantValue.Decode(byteArray, ref p);
            Documentation = new BaseVec<Str>();
            Documentation.Decode(byteArray, ref p);
            TypeSize = p - num;
        }
    }
}
