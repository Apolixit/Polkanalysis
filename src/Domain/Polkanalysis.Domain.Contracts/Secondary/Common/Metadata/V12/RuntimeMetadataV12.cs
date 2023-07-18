using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12
{
    public class RuntimeMetadataV12 : BaseType
    {
        public BaseVec<ModuleMetadataV12> Modules { get; private set; }
        public ExtrinsicMetadataV12 Extrinsic { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Modules = new BaseVec<ModuleMetadataV12>();
            Modules.Decode(byteArray, ref p);

            Extrinsic = new ExtrinsicMetadataV12();
            Extrinsic.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
