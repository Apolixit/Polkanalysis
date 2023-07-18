using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Linq;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class ModuleMetadataV11 : BaseType
    {
        public Str Name { get; private set; }
        public BaseOpt<PalletStorageMetadataV11> Storage { get; private set; }
        public BaseOpt<BaseVec<PalletCallMetadataV11>> Calls { get; private set; }
        public BaseOpt<BaseVec<PalletEventMetadataV11>> Events { get; private set; }
        public BaseVec<PalletConstantMetadataV11> Constants { get; private set; }
        public BaseVec<PalletErrorMetadataV11> Errors { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Storage = new BaseOpt<PalletStorageMetadataV11>();
            Storage.Decode(byteArray, ref p);

            Calls = new BaseOpt<BaseVec<PalletCallMetadataV11>>();
            Calls.Decode(byteArray, ref p);

            Events = new BaseOpt<BaseVec<PalletEventMetadataV11>>();
            Events.Decode(byteArray, ref p);

            Constants = new BaseVec<PalletConstantMetadataV11>();
            Constants.Decode(byteArray, ref p);

            Errors = new BaseVec<PalletErrorMetadataV11>();
            Errors.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}