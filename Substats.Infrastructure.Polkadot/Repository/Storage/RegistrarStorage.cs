using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Registrar;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using RegistrarStorageExt = Substats.Polkadot.NetApiExt.Generated.Storage.RegistrarStorage;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class RegistrarStorage : MainStorage, IRegistrarStorage
    {
        public RegistrarStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<Id> NextFreeParaIdAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Id>(RegistrarStorageExt.NextFreeParaIdParams, token);
        }

        public async Task<ParaInfo> ParasAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.ParaInfo, 
                ParaInfo>(SubstrateMapper.Instance.Map< Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(key), RegistrarStorageExt.ParasParams, token);
        }

        public async Task<Id> PendingSwapAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Id>(SubstrateMapper.Instance.Map<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(key), RegistrarStorageExt.PendingSwapParams, token);
        }
    }
}
