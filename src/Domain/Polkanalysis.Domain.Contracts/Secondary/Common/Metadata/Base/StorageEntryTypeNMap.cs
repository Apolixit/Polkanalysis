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
    /// Represent a "NMap" storage with generic Hasher
    /// </summary>
    /// <typeparam name="THasher"></typeparam>
    public class StorageEntryTypeNMap<THasher> : BaseType
        where THasher : Enum
    {
        public BaseVec<BaseEnum<THasher>> Hashers { get; private set; }

        public BaseVec<Str> KeyVec { get; private set; }

        public Str Value { get; private set; }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            int num = p;

            Hashers = new BaseVec<BaseEnum<THasher>>();
            Hashers.Decode(byteArray, ref p);

            KeyVec = new BaseVec<Str>();
            KeyVec.Decode(byteArray, ref p);

            Value = new Str();
            Value.Decode(byteArray, ref p);

            TypeSize = p - num;
        }
    }
}
