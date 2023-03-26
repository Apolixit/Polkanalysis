using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using CrowdloanStorageExt = Substats.Polkadot.NetApiExt.Generated.Storage.CrowdloanStorage;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
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
            var id = SubstrateMapper.Instance.Map<Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(key);

            return await GetStorageWithParamsAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo,
                FundInfo>
                (id, CrowdloanStorageExt.FundsParams, token);
        }

        public async Task<BaseVec<Id>> NewRaiseAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>,
                BaseVec<Id>>(CrowdloanStorageExt.NewRaiseParams, token);
        }
    }
}
