using Ajuna.NetApi;
using Substats.Domain.Contracts.Secondary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Common.Rpc
{
    public class RuntimeMetadata : IMetadata
    {
        private readonly SubstrateClient _client;
        public RuntimeMetadata(SubstrateClient client)
        {
            _client = client;
        }

        public string Origin => _client.MetaData.Origin;
        public string Magic => _client.MetaData.Magic;
        public byte Version => _client.MetaData.Version;

        private INodeMetadataV14? _nodeMetadataV14;
        public INodeMetadataV14 NodeMetadata {
            get
            {
                if(_nodeMetadataV14 == null)
                    _nodeMetadataV14 = new NodeMetadataV14(_client);

                return _nodeMetadataV14;
            }
        }
    }
}
