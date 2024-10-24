using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi.Model.Types;
using RegistrarStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.RegistrarStorage;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class RegistrarStorage : PolkadotAbstractStorage, IRegistrarStorage
    {
        public RegistrarStorage(SubstrateClientExt client, PolkadotMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<Id> NextFreeParaIdAsync(CancellationToken token)
        {
            return Map<IType, Id>(
                await _client.RegistrarStorage.NextFreeParaIdAsync(token));
        }

        public async Task<ParaInfo> ParasAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.RegistrarStorage.ParasInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.RegistrarStorage.ParasInputType with version {version}");

            return Map<IType, ParaInfo>(
                await _client.RegistrarStorage.ParasAsync(input, token));
        }

        public async Task<Id> PendingSwapAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.RegistrarStorage.PendingSwapInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.RegistrarStorage.PendingSwapInputType with version {version}");

            return Map<IType, Id>(
                await _client.RegistrarStorage.PendingSwapAsync(input, token));
        }
    }
}
