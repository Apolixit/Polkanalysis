﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using CrowdloanStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.CrowdloanStorage;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class CrowdloanStorage : MainStorage, ICrowdloanStorage
    {
        public CrowdloanStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<U32> EndingsCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(CrowdloanStorageExt.EndingsCountParams, token);
        }

        public async Task<FundInfo> FundsAsync(Id key, CancellationToken token)
        {
            var id = PolkadotMapping.Instance.Map<Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(key);

            return await GetStorageWithParamsAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo,
                FundInfo>
                (id, CrowdloanStorageExt.FundsParams, token);
        }

        public QueryStorage<Id, FundInfo> FundsQuery()
        {
            return new QueryStorage<Id, FundInfo>(
                GetAllStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo,
                FundInfo>, "Crowdloan", "Funds");
        }

        public async Task<BaseVec<Id>> NewRaiseAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>,
                BaseVec<Id>>(CrowdloanStorageExt.NewRaiseParams, token);
        }
    }
}
