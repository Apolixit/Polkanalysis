using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Substrate.NetApi;
using Substrate.NetApi.Model.Meta;

namespace Polkanalysis.Infrastructure.Blockchain.Common.Rpc
{
    public class NodeMetadataV14 : INodeMetadataV14
    {
        private readonly SubstrateClient _client;
        public NodeMetadataV14(SubstrateClient client)
        {
            _client = client;
        }

        public Dictionary<uint, NodeType> Types => _client.MetaData.NodeMetadata.Types;
        public Dictionary<uint, PalletModule> Modules => _client.MetaData.NodeMetadata.Modules;
        public ExtrinsicMetadata Extrinsic => _client.MetaData.NodeMetadata.Extrinsic;
        public uint TypeId => _client.MetaData.NodeMetadata.TypeId;
    }
}
