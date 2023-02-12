using Ajuna.NetApi.Model.Types.Primitive;
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

        public Task<U32> AuctionCounterAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<(U32, U32)> AuctionInfoAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> ReservedAmountsAsync((SubstrateAccount, Id) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<(SubstrateAccount, Id, U128)?> WinningAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
