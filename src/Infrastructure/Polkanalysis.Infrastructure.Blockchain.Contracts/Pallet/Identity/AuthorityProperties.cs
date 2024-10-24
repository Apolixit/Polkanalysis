using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity
{
    public class AuthorityProperties : BaseType
    {
        public AuthorityProperties() { }

        public AuthorityProperties(BaseVec<U8> suffix, U32 allocation)
        {
            Suffix = suffix;
            Allocation = allocation;
        }

        public BaseVec<U8> Suffix { get; set; } = default!;
        public U32 Allocation { get; set; } = default!;

        public void Create(BaseVec<U8> suffix, U32 allocation)
        {
            Suffix = suffix;
            Allocation = allocation;

            Bytes = Encode();

            TypeSize = Suffix.TypeSize + Allocation.TypeSize;
        }

        public override string TypeName()
        {
            return "AuthorityProperties";
        }

        public override byte[] Encode()
        {
            List<byte> list = [.. Suffix.Encode(), .. Allocation.Encode()];
            return list.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            int num = p;
            Suffix = new BaseVec<U8>();
            Suffix.Decode(byteArray, ref p);
            Allocation = new U32();
            Allocation.Decode(byteArray, ref p);
            int num3 = (TypeSize = p - num);
            base.Bytes = new byte[num3];
            Array.Copy(byteArray, num, base.Bytes, 0, num3);
        }
    }
}
