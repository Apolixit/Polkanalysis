using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14
{
    public class ExtrinsicMetadataV14 : BaseType
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ExtrinsicType = new TType();
            ExtrinsicType.Decode(byteArray, ref p);

            Version = new U8();
            Version.Decode(byteArray, ref p);

            SignedExtensions = new BaseVec<SignedExtensionMetadataV14>();
            SignedExtensions.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public TType ExtrinsicType { get; private set; }
        public U8 Version { get; private set; }
        public BaseVec<SignedExtensionMetadataV14> SignedExtensions { get; private set; }
    }
}
