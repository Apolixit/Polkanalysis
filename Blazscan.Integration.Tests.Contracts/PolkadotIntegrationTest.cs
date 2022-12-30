﻿using Blazscan.Configuration.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Integration.Tests.Contracts
{
    public abstract class PolkadotIntegrationTest : IntegrationTest
    {
        public PolkadotIntegrationTest() {
        }

        protected override SubstrateEndpoint GetEndpoint()
        {
            return new SubstrateEndpoint()
            {
                Name = "Polkadot",
                Endpoint = "wss://rpc.polkadot.io",
            };
        }
    }
}
