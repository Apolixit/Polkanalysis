using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common
{
    /// <summary>
    /// Metadata contract
    /// Based on <see cref="Substrate.NetApi.Model.Meta.MetaData"/> implementation
    /// </summary>
    public interface IMetadata
    {
        public string Origin { get; }

        public string Magic { get; }

        public byte Version { get; }

        public INodeMetadataV14 NodeMetadata { get; }
    }
}
