using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13
{
    public class RuntimeMetadataV13 : BaseType
    {
        public BaseVec<ModuleMetadataV13> Modules { get; private set; }
        public ExtrinsicMetadataV13 Extrinsic { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Modules = new BaseVec<ModuleMetadataV13>();
            Modules.Decode(byteArray, ref p);

            Extrinsic = new ExtrinsicMetadataV13();
            Extrinsic.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
