using Ajuna.NetApi.Model.Meta;
using Substats.Domain.Contracts.Secondary.Common;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Common
{
    public class NodeMetadataV14 : INodeMetadataV14
    {
        private readonly SubstrateClientExt _client;
        public NodeMetadataV14(SubstrateClientExt client)
        {
            _client = client;
        }

        public Dictionary<uint, NodeType> Types => _client.MetaData.NodeMetadata.Types;
        public Dictionary<uint, PalletModule> Modules => _client.MetaData.NodeMetadata.Modules;
        public ExtrinsicMetadata Extrinsic => _client.MetaData.NodeMetadata.Extrinsic;
        public uint TypeId => _client.MetaData.NodeMetadata.TypeId;
    }
}
