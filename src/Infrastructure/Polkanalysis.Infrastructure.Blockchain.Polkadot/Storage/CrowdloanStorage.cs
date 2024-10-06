using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan;
using Ardalis.GuardClauses;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class CrowdloanStorage : PolkadotAbstractStorage, ICrowdloanStorage
    {
        public CrowdloanStorage(SubstrateClientExt client, PolkadotMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<U32> EndingsCountAsync(CancellationToken token)
        {
            return await _client.CrowdloanStorage.EndingsCountAsync(token);
        }

        public async Task<FundInfo> FundsAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.CrowdloanStorage.FundsInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.CrowdloanStorage.FundsInputType with version {version}");

            return Map<FundInfoBase, FundInfo>(
                await _client.CrowdloanStorage.FundsAsync(input!, token));
        }

        public async Task<IQueryStorage<Id, FundInfo>> FundsQueryAsync(CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var sourceKeyType = _client.CrowdloanStorage.FundsInputType(version);
            var storageKeyType = FundInfoBase.TypeByVersion(version);
            var storageFunction = new QueryStorageFunction("Crowdloan", "Funds", sourceKeyType, storageKeyType, 4);

            return new QueryStorage<Id, FundInfo>(GetAllStorageAsync<Id, FundInfo>, storageFunction);
        }

        public async Task<BaseVec<Id>> NewRaiseAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<Id>>(await _client.CrowdloanStorage.NewRaiseAsync(token));
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
