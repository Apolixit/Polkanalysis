using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9
{
    public class PalletConstantMetadataV9 : BaseType, IMetadataName
    {
        public Str Name { get; set; }

        public Str ConstantType { get; set; }

        public ByteGetter Value { get; set; }

        public BaseVec<Str> Documentation { get; set; }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            int num = p;
            Name = new Str();
            Name.Decode(byteArray, ref p);
            ConstantType = new Str();
            ConstantType.Decode(byteArray, ref p);
            Value = new ByteGetter();
            Value.Decode(byteArray, ref p);
            Documentation = new BaseVec<Str>();
            Documentation.Decode(byteArray, ref p);
            TypeSize = p - num;
        }
    }
}
