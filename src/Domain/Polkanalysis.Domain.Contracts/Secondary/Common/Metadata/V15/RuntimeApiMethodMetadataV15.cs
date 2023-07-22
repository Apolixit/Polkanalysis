using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V15
{
    public class RuntimeApiMethodMetadataV15 : BaseType, IMetadataName
    {
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Inputs = new BaseVec<RuntimeApiMethodParamMetadataV15>();
            Inputs.Decode(byteArray, ref p);

            Output = new TType();
            Output.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public Str Name { get; private set; }
        public BaseVec<RuntimeApiMethodParamMetadataV15> Inputs { get; private set; }
        public TType Output { get; private set; }
        public BaseVec<Str> Docs { get; private set; }
    }
}
