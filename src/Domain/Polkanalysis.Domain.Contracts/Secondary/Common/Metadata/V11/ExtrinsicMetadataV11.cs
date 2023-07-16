using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class ExtrinsicMetadataV11 : BaseType
    {
        public U8 Version { get; private set; }
        public BaseVec<Str> SignedExtensions { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Version = new U8();
            Version.Decode(byteArray, ref p);

            SignedExtensions = new BaseVec<Str>();
            SignedExtensions.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
