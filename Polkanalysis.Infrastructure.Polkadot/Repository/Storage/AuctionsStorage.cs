﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Math;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Auctions;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using AuctionsStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.AuctionsStorage;

namespace Polkanalysis.Infrastructure.Polkadot.Repository.Storage
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
            return await GetStorageAsync<U32>(AuctionsStorageExt.AuctionCounterParams, token);
        }

        public async Task<BaseTuple<U32, U32>> AuctionInfoAsync(CancellationToken token)
        {
            return await GetStorageAsync<BaseTuple<U32, U32>>(AuctionsStorageExt.AuctionInfoParams, token);
        }

        public async Task<U128> ReservedAmountsAsync(BaseTuple<SubstrateAccount, Id> key, CancellationToken token)
        {
            var param = SubstrateMapper.Instance.Map<
                BaseTuple<SubstrateAccount, Id>,
                BaseTuple<AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>>(key);

            return await GetStorageWithParamsAsync<BaseTuple<AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id >, U128 >(param, AuctionsStorageExt.ReservedAmountsParams, token);
        }

        public async Task<Winning> WinningAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<U32, Arr36BaseOpt, Winning>(key, AuctionsStorageExt.WinningParams, token);

            //return SubstrateMapper.Instance.Map<Arr36BaseOpt, BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[]>(result)
            //    ?? new BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[0];
        }
    }
}
