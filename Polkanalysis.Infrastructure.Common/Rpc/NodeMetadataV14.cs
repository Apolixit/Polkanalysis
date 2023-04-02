﻿using Ajuna.NetApi;
using Ajuna.NetApi.Model.Meta;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Rpc
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