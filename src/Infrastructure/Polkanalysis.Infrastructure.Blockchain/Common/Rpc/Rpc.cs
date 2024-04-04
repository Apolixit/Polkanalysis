using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Substrate.NetApi;
using Substrate.NetApi.Modules.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Common.Rpc
{
    public class Rpc : IRpc
    {
        private readonly SubstrateClient _client;

        public Rpc(SubstrateClient client)
        {
            _client = client;
        }

        public IChain Chain => _client.Chain;

        public IState State => _client.State;

        public IAuthor Author => _client.Author;

        public ISystem System => _client.System;
    }
}
