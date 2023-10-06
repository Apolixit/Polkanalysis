using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Auctions;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto;
using AuctionsStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.AuctionsStorage;
using Substrate.NetApi.Model.Types.Base.Abstraction;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    /// <summary>
    /// Auctions storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="PolkadotMapping.AuctionsStorageProfile"/>
    /// </summary>
    public class AuctionsStorage : MainStorage, IAuctionsStorage
    {
        public AuctionsStorage(SubstrateClientExt client, ILogger logger) : base(client, logger)
        {
        }

        public async Task<U32> AuctionCounterAsync(CancellationToken token)
        {
            return await _client.AuctionsStorage.AuctionCounterAsync(token);
        }

        public async Task<BaseTuple<U32, U32>> AuctionInfoAsync(CancellationToken token)
        {
            return (BaseTuple<U32, U32>)await _client.AuctionsStorage.AuctionInfoAsync(token);
        }

        public async Task<U128> ReservedAmountsAsync(BaseTuple<SubstrateAccount, Id> key, CancellationToken token)
        {
            var param = await MapWithVersionAsync<BaseTuple<SubstrateAccount, Id>, IBaseEnumerable>(key, token);
            return await _client.AuctionsStorage.ReservedAmountsAsync(param, token);
        }

        public async Task<Winning> WinningAsync(U32 key, CancellationToken token)
        {
            var res = await _client.AuctionsStorage.WinningAsync(key, token);
            return Map<Arr36BaseOpt, Winning>(res);
        }
    }
}
