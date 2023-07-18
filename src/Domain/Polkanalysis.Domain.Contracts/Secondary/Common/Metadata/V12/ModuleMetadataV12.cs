using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12
{
    public class ModuleMetadataV12 : BaseType
    {
        public Str Name { get; private set; }
        public BaseOpt<PalletStorageMetadataV12> Storage { get; private set; }
        public BaseOpt<BaseVec<PalletCallMetadataV12>> Calls { get; private set; }
        public BaseOpt<BaseVec<PalletEventMetadataV12>> Events { get; private set; }
        public BaseVec<PalletConstantMetadataV12> Constants { get; private set; }
        public BaseVec<PalletErrorMetadataV12> Errors { get; private set; }
        public U8 Index { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Storage = new BaseOpt<PalletStorageMetadataV12>();
            Storage.Decode(byteArray, ref p);

            Calls = new BaseOpt<BaseVec<PalletCallMetadataV12>>();
            Calls.Decode(byteArray, ref p);

            Events = new BaseOpt<BaseVec<PalletEventMetadataV12>>();
            Events.Decode(byteArray, ref p);

            Constants = new BaseVec<PalletConstantMetadataV12>();
            Constants.Decode(byteArray, ref p);

            Errors = new BaseVec<PalletErrorMetadataV12>();
            Errors.Decode(byteArray, ref p);

            Index = new U8();
            Index.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}