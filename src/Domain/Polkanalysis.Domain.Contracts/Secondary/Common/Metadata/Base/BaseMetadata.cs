using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base
{
    public abstract class BaseMetadata<T> : BaseType
        where T : BaseType, new()
    {
        protected BaseMetadata()
        {
        }

        protected BaseMetadata(string hex)
        {
            Create(hex);
        }

        public abstract MetadataVersion Version { get; }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            MetaDataInfo = new MetaDataInfo();
            MetaDataInfo.Decode(byteArray, ref p);

            RuntimeMetadataData = new T();
            RuntimeMetadataData.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public MetaDataInfo MetaDataInfo { get; private set; }
        public T RuntimeMetadataData { get; private set; }
    }
}
