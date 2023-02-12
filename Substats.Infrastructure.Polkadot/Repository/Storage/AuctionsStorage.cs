using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Auctions;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class AuctionsStorage : IAuctionsStorage
    {
        private readonly SubstrateClientExt _client;
        public AuctionsStorage(SubstrateClientExt client)
        {
            _client = client;
        }
        
        
    }
}
