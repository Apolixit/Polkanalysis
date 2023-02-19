using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using AutoMapper;
using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Auctions;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
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
        private readonly IMapper _mapper;
        public AuctionsStorage(SubstrateClientExt client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public Task<U32> AuctionCounterAsync(CancellationToken token)
        {
            return _client.AuctionsStorage.AuctionCounter(token);
        }

        public async Task<(U32, U32)> AuctionInfoAsync(CancellationToken token)
        {
            var info = await _client.AuctionsStorage.AuctionInfo(token);
            return _mapper.Map<(U32, U32)>(info);
        }

        public async Task<U128> ReservedAmountsAsync((SubstrateAccount, Id) key, CancellationToken token)
        {
            return await _client.AuctionsStorage.ReservedAmounts(
                _mapper.Map<BaseTuple<AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>>(key), 
                token);
        }

        public async Task<(SubstrateAccount, Id, U128)?> WinningAsync(U32 key, CancellationToken token)
        {
            var result = await _client.AuctionsStorage.Winning(key, token);
            return _mapper.Map<(SubstrateAccount, Id, U128)?>(result);
        }
    }
}
