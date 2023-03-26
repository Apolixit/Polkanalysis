using Ajuna.NetApi;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Rpc
{
    public class RuntimeVersion : IRuntimeVersion
    {
        private readonly SubstrateClient _client;
        public RuntimeVersion(SubstrateClient client)
        {
            _client = client;
        }

        public object[][] Apis => _client.RuntimeVersion.Apis;
        public int AuthoringVersion => _client.RuntimeVersion.AuthoringVersion;
        public string ImplName => _client.RuntimeVersion.ImplName;
        public uint ImplVersion => _client.RuntimeVersion.ImplVersion;
        public string SpecName => _client.RuntimeVersion.SpecName;
        public uint SpecVersion => _client.RuntimeVersion.SpecVersion;
        public uint TransactionVersion => _client.RuntimeVersion.TransactionVersion;
    }
}
