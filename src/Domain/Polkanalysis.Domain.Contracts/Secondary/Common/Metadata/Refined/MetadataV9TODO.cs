using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Refined
{
    public class MetadataV9TODO
    {
        public string Origin { get; }

        public string Magic { get; }

        public byte Version { get; }

        public NodeMetadataV9 NodeMetadata { get; }

        public MetadataV9TODO(string hexData)
        {

        }
    }
}
