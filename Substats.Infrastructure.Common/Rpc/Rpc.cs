﻿using Ajuna.NetApi;
using Ajuna.NetApi.Modules;
using Ajuna.NetApi.Modules.Contracts;
using Substats.Domain.Contracts.Secondary.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Common.Rpc
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
