using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13
{
    public class ModuleMetadataV13 : BaseType
    {
        public Str Name { get; private set; }
        public BaseOpt<PalletStorageMetadataV13> Storage { get; private set; }
        public BaseOpt<BaseVec<PalletCallMetadataV13>> Calls { get; private set; }
        public BaseOpt<BaseVec<PalletEventMetadataV13>> Events { get; private set; }
        public BaseVec<PalletConstantMetadataV13> Constants { get; private set; }
        public BaseVec<PalletErrorMetadataV13> Errors { get; private set; }
        public U8 Index { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Storage = new BaseOpt<PalletStorageMetadataV13>();
            Storage.Decode(byteArray, ref p);

            Calls = new BaseOpt<BaseVec<PalletCallMetadataV13>>();
            Calls.Decode(byteArray, ref p);

            Events = new BaseOpt<BaseVec<PalletEventMetadataV13>>();
            Events.Decode(byteArray, ref p);

            Constants = new BaseVec<PalletConstantMetadataV13>();
            Constants.Decode(byteArray, ref p);

            Errors = new BaseVec<PalletErrorMetadataV13>();
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