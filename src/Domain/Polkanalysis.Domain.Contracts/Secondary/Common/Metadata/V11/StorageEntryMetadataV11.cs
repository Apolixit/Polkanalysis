using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class StorageEntryMetadataV11 : BaseType
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            StorageName = new Str();
            StorageName.Decode(byteArray, ref p);

            StorageModifier = new BaseEnum<StorageType.ModifierV9>();
            StorageModifier.Decode(byteArray, ref p);

            StorageType = new BaseEnumExt<StorageType.TypeV9, Str, StorageEntryTypeMapV11, StorageEntryTypeDoubleMapV11>();
            StorageType.Decode(byteArray, ref p);

            StorageDefault = new ByteGetter();
            StorageDefault.Decode(byteArray, ref p);

            Documentation = new BaseVec<Str>();
            Documentation.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Str StorageName { get; private set; }
        public BaseEnum<StorageType.ModifierV9> StorageModifier { get; private set; }
        public BaseEnumExt<StorageType.TypeV9, Str, StorageEntryTypeMapV11, StorageEntryTypeDoubleMapV11> StorageType { get; private set; }
        public ByteGetter StorageDefault { get; private set; }
        public BaseVec<Str> Documentation { get; private set; }
    }
}