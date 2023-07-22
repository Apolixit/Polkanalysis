using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using static Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.StorageType;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14
{
    public class PalletStorageMetadataV14 : BaseType
    {
        public Str Prefix { get; private set; }

        public BaseVec<StorageEntryMetadataV14> Entries { get; private set; }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            int num = p;
            Prefix = new Str();
            Prefix.Decode(byteArray, ref p);
            Entries = new BaseVec<StorageEntryMetadataV14>();
            Entries.Decode(byteArray, ref p);
            TypeSize = p - num;
        }
    }

    public class StorageEntryMetadataV14 : BaseType, IMetadataName
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

            StorageModifier = new BaseEnum<StorageType.ModifierV9>();
            StorageModifier.Decode(byteArray, ref p);

            StorageType = new BaseEnumExt<StorageType.Type, TType, StorageEntryTypeMapV14>();
            StorageType.Decode(byteArray, ref p);

            StorageDefault = new ByteGetter();
            StorageDefault.Decode(byteArray, ref p);

            Documentation = new BaseVec<Str>();
            Documentation.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Str Name { get; private set; }
        public BaseEnum<StorageType.ModifierV9> StorageModifier { get; private set; }
        public BaseEnumExt<StorageType.Type, TType, StorageEntryTypeMapV14> StorageType { get; private set; }
        public ByteGetter StorageDefault { get; private set; }
        public BaseVec<Str> Documentation { get; private set; }
    }

    public class StorageEntryTypeMapV14 : BaseType
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Hashers = new BaseVec<BaseEnum<Hasher>>();
            Hashers.Decode(byteArray, ref p);

            Key = new TType();
            Key.Decode(byteArray, ref p);

            Value = new TType();
            Value.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public BaseVec<BaseEnum<Hasher>> Hashers { get; private set; }
        public TType Key { get; private set; }
        public TType Value { get; private set; }
    }

    public class PalletCallMetadata14 : BaseType, IMetadataName
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            CallType = new TType();
            CallType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public TType CallType { get; private set; }
        public Str Name => new Str(CallType.ToString());
    }

    public class PalletEventMetadataV14 : BaseType, IMetadataName
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            EventType = new TType();
            EventType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public TType EventType { get; private set; }

        public Str Name => new Str(EventType.ToString());
    }

    public class PalletConstantMetadataV14 : BaseType, IMetadataName
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

            ConstantType = new TType();
            ConstantType.Decode(byteArray, ref p);

            ConstantValue = new ByteGetter();
            ConstantValue.Decode(byteArray, ref p);

            Documentation = new BaseVec<Str>();
            Documentation.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Str Name { get; private set; }
        public TType ConstantType { get; private set; }
        public ByteGetter ConstantValue { get; private set; }
        public BaseVec<Str> Documentation { get; private set; }
    }

    public class PalletErrorMetadataV14 : BaseType, IMetadataName
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ErrorType = new TType();
            ErrorType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public TType ErrorType { get; private set; }
        public Str Name => new Str(ErrorType.ToString());
    }
}
