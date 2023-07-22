using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base.Portable;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14
{
    public class RuntimeMetadataV14 : BaseType
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Lookup = new PortableRegistry();
            Lookup.Decode(byteArray, ref p);

            Modules = new BaseVec<ModuleMetadataV14>();
            Modules.Decode(byteArray, ref p);

            Extrinsic = new ExtrinsicMetadataV14();
            Extrinsic.Decode(byteArray, ref p);

            TypeId = new TType();
            TypeId.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public PortableRegistry Lookup { get; private set; }

        public BaseVec<ModuleMetadataV14> Modules { get; private set; }

        public ExtrinsicMetadataV14 Extrinsic { get; private set; }

        public TType TypeId { get; private set; }
    }
}
