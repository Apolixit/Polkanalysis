using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using ParasStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.ParasStorage;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Model.Types.Base.Abstraction;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class ParasStorage : MainStorage, IParasStorage
    {
        public ParasStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BaseVec<Id>> ActionsQueueAsync(U32 key, CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<Id>>(await _client.ParasStorage.ActionsQueueAsync(key, token));
        }

        public async Task<DataCode> CodeByHashAsync(Hash key, CancellationToken token)
        {
            var hash = await MapHashAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeBase, DataCode>(
                await _client.ParasStorage.CodeByHashAsync(hash, token));
        }

        public async Task<U32> CodeByHashRefsAsync(Hash key, CancellationToken token)
        {
            var hash = await MapHashAsync(key, token);
            return await _client.ParasStorage.CodeByHashRefsAsync(hash, token);
        }

        public async Task<Hash> CurrentCodeHashAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase, Hash>(
                await _client.ParasStorage.CurrentCodeHashAsync(id, token));
        }

        public async Task<Hash> FutureCodeHashAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase, Hash>(
                await _client.ParasStorage.FutureCodeHashAsync(id, token));
        }

        public async Task<U32> FutureCodeUpgradesAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return await _client.ParasStorage.FutureCodeUpgradesAsync(id, token);
        }

        public async Task<DataCode> HeadsAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.HeadDataBase, DataCode>(
                await _client.ParasStorage.HeadsAsync(id, token));
        }

        public async Task<BaseVec<Id>> ParachainsAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<Id>>(
                await _client.ParasStorage.ParachainsAsync(token));
        }

        public async Task<EnumParaLifecycle> ParaLifecyclesAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<IBaseEnum, EnumParaLifecycle>(
                await _client.ParasStorage.ParaLifecyclesAsync(id, token));
        }

        public async Task<Hash> PastCodeHashAsync(BaseTuple<Id, U32> key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<ParaPastCodeMeta> PastCodeMetaAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras.ParaPastCodeMetaBase, ParaPastCodeMeta>(
                await _client.ParasStorage.PastCodeMetaAsync(id, token));
        }

        public async Task<BaseVec<BaseTuple<Id, U32>>> PastCodePruningAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseTuple<Id, U32>>>(await _client.ParasStorage.PastCodePruningAsync(token));
        }

        public async Task<BaseVec<Hash>> PvfActiveVoteListAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<Hash>>(await _client.ParasStorage.PvfActiveVoteListAsync(token));
        }

        public async Task<PvfCheckActiveVoteState> PvfActiveVoteMapAsync(Hash key, CancellationToken token)
        {
            var hash = await MapHashAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras.PvfCheckActiveVoteStateBase, PvfCheckActiveVoteState>(
                await _client.ParasStorage.PvfActiveVoteMapAsync(hash, token));
        }

        public async Task<ParaGenesisArgs> UpcomingParasGenesisAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras.ParaGenesisArgsBase, ParaGenesisArgs>(
                await _client.ParasStorage.UpcomingParasGenesisAsync(id, token));
        }

        public async Task<BaseVec<BaseTuple<Id, U32>>> UpcomingUpgradesAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseTuple<Id, U32>>>(await _client.ParasStorage.UpcomingUpgradesAsync(token));
        }

        public async Task<BaseVec<BaseTuple<Id, U32>>> UpgradeCooldownsAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseTuple<Id, U32>>>(await _client.ParasStorage.UpgradeCooldownsAsync(token));
        }

        public async Task<EnumUpgradeGoAhead> UpgradeGoAheadSignalAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<IBaseEnum, EnumUpgradeGoAhead>(await _client.ParasStorage.UpgradeGoAheadSignalAsync(id, token));
        }

        public async Task<EnumUpgradeRestriction> UpgradeRestrictionSignalAsync(Id key, CancellationToken token)
        {
            var id = await MapIdAsync(key, token);
            return Map<IBaseEnum, EnumUpgradeRestriction>(await _client.ParasStorage.UpgradeRestrictionSignalAsync(id, token));
        }
    }
}
