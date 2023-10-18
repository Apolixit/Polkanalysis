using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Substrate.NetApi.Model.Types.Base.Abstraction;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class CrowdloanStorage : MainStorage, ICrowdloanStorage
    {
        public CrowdloanStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

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

        public QueryStorage<Id, FundInfo> FundsQuery()
        {
            //return new QueryStorage<Id, FundInfo>(
            //    GetAllStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
            //    Id,
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo,
            //    FundInfo>, "Crowdloan", "Funds");
            throw new NotImplementedException();
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
