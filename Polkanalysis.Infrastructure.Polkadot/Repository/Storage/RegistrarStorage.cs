using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Registrar;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using RegistrarStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.RegistrarStorage;

namespace Polkanalysis.Infrastructure.Polkadot.Repository.Storage
{
    public class RegistrarStorage : MainStorage, IRegistrarStorage
    {
        public RegistrarStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<Id> NextFreeParaIdAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Id>(RegistrarStorageExt.NextFreeParaIdParams, token);
        }

        public async Task<ParaInfo> ParasAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.ParaInfo, 
                ParaInfo>(SubstrateMapper.Instance.Map< Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(key), RegistrarStorageExt.ParasParams, token);
        }

        public async Task<Id> PendingSwapAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Id>(SubstrateMapper.Instance.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(key), RegistrarStorageExt.PendingSwapParams, token);
        }
    }
}
