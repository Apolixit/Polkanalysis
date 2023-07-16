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
    /// Represent a "Map" storage with generic Hasher
    /// </summary>
    /// <typeparam name="THasher"></typeparam>
    public abstract class StorageEntryTypeMap<THasher> : BaseType
        where THasher : Enum
    {
        public BaseEnum<THasher> Hasher { get; private set; }

        public Str Key { get; private set; }

        public Str Value { get; private set; }
        public Bool Linked { get; private set; }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            int num = p;

            Hasher = new BaseEnum<THasher>();
            Hasher.Decode(byteArray, ref p);

            var Key = new Str();
            Key.Decode(byteArray, ref p);

            var Value = new Str();
            Value.Decode(byteArray, ref p);

            Linked = new Bool();
            Linked.Decode(byteArray, ref p);

            TypeSize = p - num;
        }
    }
}
