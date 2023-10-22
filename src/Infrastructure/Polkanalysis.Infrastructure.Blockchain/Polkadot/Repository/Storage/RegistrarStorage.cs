using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using RegistrarStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.RegistrarStorage;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class RegistrarStorage : MainStorage, IRegistrarStorage
    {
        public RegistrarStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Id> NextFreeParaIdAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase, Id>(
                await _client.RegistrarStorage.NextFreeParaIdAsync(token));
        }

        public async Task<ParaInfo> ParasAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.paras_registrar.ParaInfoBase, ParaInfo>(
                await _client.RegistrarStorage.ParasAsync(id, token));
        }

        public async Task<Id> PendingSwapAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase, Id>(
                await _client.RegistrarStorage.PendingSwapAsync(id, token));
        }
    }
}
