using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base
{
    /// <summary>
    /// Represent a "Double Map" storage with generic Hasher
    /// </summary>
    /// <typeparam name="THasher"></typeparam>
    public class StorageEntryTypeDoubleMap<THasher> : BaseType
        where THasher : Enum
    {
        public BaseEnum<THasher> Key1Hasher { get; private set; }
        public BaseEnum<THasher> Key2Hasher { get; private set; }

        public Str Key1 { get; private set; }
        public Str Key2 { get; private set; }

        public Str Value { get; private set; }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            int num = p;

            Key1Hasher = new BaseEnum<THasher>();
            Key1Hasher.Decode(byteArray, ref p);

            Key1 = new Str();
            Key1.Decode(byteArray, ref p);

            Key2 = new Str();
            Key2.Decode(byteArray, ref p);

            Value = new Str();
            Value.Decode(byteArray, ref p);

            Key2Hasher = new BaseEnum<THasher>();
            Key2Hasher.Decode(byteArray, ref p);

            TypeSize = p - num;
        }
    }
}
