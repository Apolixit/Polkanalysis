using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Substrate.NetApi.Model.Meta.Storage;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9
{
    public class RuntimeMetadataV9 : BaseType
    {
        public BaseVec<ModuleMetadataV9> Modules { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Modules = new BaseVec<ModuleMetadataV9>();
            Modules.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}
