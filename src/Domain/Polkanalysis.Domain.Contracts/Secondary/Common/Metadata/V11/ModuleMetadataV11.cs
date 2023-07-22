using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Linq;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class ModuleMetadataV11 : BaseType, IMetadataName
    {
        public Str Name { get; set; }
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

        public MetadataDifferentialModulesV11 ToDifferentialModule(CompareStatus status)
        {
            return new MetadataDifferentialModulesV11()
            {
                ModuleName = Name.Value,
                CompareStatus = status,
                Calls = Calls.Value.Value.Select(y => (status, y)),
                Events = Events.Value.Value.Select(y => (status, y)),
                Constants = Constants.Value.Select(y => (status, y)),
                Errors = Errors.Value.Select(y => (status, y)),
                Storage = Storage.Value != null ? 
                    Storage.Value.Entries.Value.Select(x => (Storage.Value.Prefix.Value, (status, x))) : 
                    Enumerable.Empty<(string, (CompareStatus, StorageEntryMetadataV11))>(),
            };
        }
    }
}