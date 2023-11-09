using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class CrowdloanStorage : MainStorage, ICrowdloanStorage
    {
        public CrowdloanStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<U32> EndingsCountAsync(CancellationToken token)
        {
            return await _client.CrowdloanStorage.EndingsCountAsync(token);
        }

        public async Task<FundInfo> FundsAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan.FundInfoBase, FundInfo>(
                await _client.CrowdloanStorage.FundsAsync(id, token));
        }

        public async Task<QueryStorage<Id, FundInfo>> FundsQueryAsync(CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var sourceKeyType = _client.CrowdloanStorage.FundsInputType(version);
            var storageKeyType = FundInfoBase.TypeByVersion(version);
            var storageFunction = new QueryStorageFunction("Crowdloan", "Funds", sourceKeyType, storageKeyType, 4);

            return new QueryStorage<Id, FundInfo>(GetAllStorageAsync<Id, FundInfo>, storageFunction);
        }

        public async Task<BaseVec<Id>> NewRaiseAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<Id>>(await _client.CrowdloanStorage.NewRaiseAsync(token));
        }

        public async Task<U32> NextFundIndexAsync(CancellationToken token)
        {
            return await _client.CrowdloanStorage.NextFundIndexAsync(token);
        }

        public async Task<U32> NextTrieIndexAsync(CancellationToken token)
        {
            return await _client.CrowdloanStorage.NextTrieIndexAsync(token);
        }
    }
}
