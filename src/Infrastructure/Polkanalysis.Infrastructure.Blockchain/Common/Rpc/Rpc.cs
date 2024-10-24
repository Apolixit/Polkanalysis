using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Substrate.NetApi;
using Substrate.NetApi.Modules.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Common.Rpc
{
    public class Rpc : IRpc
    {
        private readonly SubstrateClient _client;
        private readonly ITmpChain _customChain;

        //public Rpc(SubstrateClient client)
        //{
        //    _customChain = client.Chain;
        //}

        public Rpc(SubstrateClient client, ITmpChain customChain)
        {
            _client = client;
            _customChain = customChain;
        }

        public ITmpChain Chain => _customChain; //_client.Chain;

        public IState State => _client.State;

        public IAuthor Author => _client.Author;

        public ISystem System => _client.System;
    }
}
