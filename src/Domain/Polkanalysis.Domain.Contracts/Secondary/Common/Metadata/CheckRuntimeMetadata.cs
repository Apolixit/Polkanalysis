using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata
{
    public class CheckRuntimeMetadata
    {
        public MetaDataInfo MetaDataInfo { get; private set; }

        public CheckRuntimeMetadata(string hexMetadata)
        {
            Guard.Against.NullOrEmpty(hexMetadata);

            var bytes = Utils.HexToByteArray(hexMetadata);

            int p = 0;
            MetaDataInfo = new MetaDataInfo();
            MetaDataInfo.Decode(bytes, ref p);
        }
    }
}
