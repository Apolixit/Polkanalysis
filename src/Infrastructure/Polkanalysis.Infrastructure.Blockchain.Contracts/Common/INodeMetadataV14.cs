using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Common
{
    /// <summary>
    /// Based on <see cref="Substrate.NetApi.Model.Meta.NodeMetadataV14"/> implementation
    /// </summary>
    public interface INodeMetadataV14
    {
        public Dictionary<uint, NodeType> Types { get; }

        public Dictionary<uint, PalletModule> Modules { get; }

        public ExtrinsicMetadata Extrinsic { get; }

        public uint TypeId { get; }
    }
}
