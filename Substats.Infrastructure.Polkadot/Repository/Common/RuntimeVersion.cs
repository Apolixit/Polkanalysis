﻿using Substats.Domain.Contracts.Secondary.Common;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Common
{
    public class RuntimeVersion : IRuntimeVersion
    {
        private readonly SubstrateClientExt _client;
        public RuntimeVersion(SubstrateClientExt client)
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
