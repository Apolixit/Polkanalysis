using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V15
{
    public class ModuleMetadataV15 : BaseType, IMetadataName
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Storage = new BaseOpt<PalletStorageMetadataV14>();
            Storage.Decode(byteArray, ref p);

            Calls = new BaseOpt<PalletCallMetadataV14>();
            Calls.Decode(byteArray, ref p);

            Events = new BaseOpt<PalletEventMetadataV14>();
            Events.Decode(byteArray, ref p);

            Constants = new BaseVec<PalletConstantMetadataV14>();
            Constants.Decode(byteArray, ref p);

            Errors = new BaseOpt<PalletErrorMetadataV14>();
            Errors.Decode(byteArray, ref p);

            Index = new U8();
            Index.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Str Name { get; private set; }
        public BaseOpt<PalletStorageMetadataV14> Storage { get; private set; }
        public BaseOpt<PalletCallMetadataV14> Calls { get; private set; }
        public BaseOpt<PalletEventMetadataV14> Events { get; private set; }
        public BaseVec<PalletConstantMetadataV14> Constants { get; private set; }
        public BaseOpt<PalletErrorMetadataV14> Errors { get; private set; }
        public U8 Index { get; private set; }
        public BaseVec<Str> Docs {get; private set; }

        public MetadataDifferentialModulesV15 ToDifferentialModules(CompareStatus status)
        {
            return new MetadataDifferentialModulesV15()
            {
                ModuleName = Name.Value,
                CompareStatus = status,
                Calls = new List<(CompareStatus, PalletCallMetadataV14)>() { (status, Calls.Value) },
                Events = new List<(CompareStatus, PalletEventMetadataV14)>() { (status, Events.Value) },
                Constants = Constants.Value.Select(y => (status, y)),
                Errors = new List<(CompareStatus, PalletErrorMetadataV14)>() { (status, Errors.Value) },
                Storage = Storage.Value != null ?
                    Storage.Value.Entries.Value.Select(x => (Storage.Value.Prefix.Value, (status, x))) :
                    Enumerable.Empty<(string, (CompareStatus, StorageEntryMetadataV14))>(),
            };
        }
    }
}