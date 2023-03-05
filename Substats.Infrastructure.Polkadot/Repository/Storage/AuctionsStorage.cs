using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Auctions;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using Substats.Polkadot.NetApiExt.Generated.Types.Base;
using AuctionsStorageExt = Substats.Polkadot.NetApiExt.Generated.Storage.AuctionsStorage;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    /// <summary>
    /// Auctions storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="SubstrateMapper.AuctionsStorageProfile"/>
    /// </summary>
    public class AuctionsStorage : MainStorage, IAuctionsStorage
    {
        public AuctionsStorage(SubstrateClientExt client, ILogger logger) : base(client, logger)
        {
        }

        public async Task<U32> AuctionCounterAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(AuctionsStorageExt.AuctionCounterParams(), token) ?? new U32();
        }

        public async Task<BaseTuple<U32, U32>> AuctionInfoAsync(CancellationToken token)
        {
            return await GetStorageAsync<BaseTuple<U32, U32>>(AuctionsStorageExt.AuctionInfoParams(), token) ?? new BaseTuple<U32, U32>();
        }

        public async Task<U128> ReservedAmountsAsync(BaseTuple<SubstrateAccount, Id> key, CancellationToken token)
        {
            var param = AuctionsStorageExt.ReservedAmountsParams(SubstrateMapper.Instance.Map<BaseTuple<AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>>(key));
            return await GetStorageAsync<U128>(param, token);
        }

        public async Task<BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[]> WinningAsync(U32 key, CancellationToken token)
        {
            string parameters = AuctionsStorageExt.WinningParams(key);
            var result = await GetStorageAsync<Arr36BaseOpt>(parameters, token);

            return SubstrateMapper.Instance.Map<Arr36BaseOpt, BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[]>(result)
                ?? new BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[0];
        }
    }
}
