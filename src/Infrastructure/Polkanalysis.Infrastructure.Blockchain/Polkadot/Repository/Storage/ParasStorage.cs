using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NetApi.Model.Types;
using Ardalis.GuardClauses;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class ParasStorage : MainStorage, IParasStorage
    {
        public ParasStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<BaseVec<Id>> ActionsQueueAsync(U32 key, CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<Id>>(await _client.ParasStorage.ActionsQueueAsync(key, token));
        }

        public async Task<DataCode> CodeByHashAsync(Hash key, CancellationToken token)
        {
            var hash = await MapHashAsync(key, token);
            return Map<IType, DataCode>(
                await _client.ParasStorage.CodeByHashAsync(hash, token));
        }

        public async Task<U32> CodeByHashRefsAsync(Hash key, CancellationToken token)
        {
            var hash = await MapHashAsync(key, token);
            return await _client.ParasStorage.CodeByHashRefsAsync(hash, token);
        }

        public async Task<Hash> CurrentCodeHashAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.CurrentCodeHashInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.CurrentCodeHashAsync with version {version}");

            return Map<IType, Hash>(
                await _client.ParasStorage.CurrentCodeHashAsync(input, token));
        }

        public async Task<Hash> FutureCodeHashAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.FutureCodeHashInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.FutureCodeHashAsync with version {version}");

            return Map<IType, Hash>(
                await _client.ParasStorage.FutureCodeHashAsync(input, token));
        }

        public async Task<U32> FutureCodeUpgradesAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.FutureCodeUpgradesInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.FutureCodeUpgradesAsync with version {version}");

            return await _client.ParasStorage.FutureCodeUpgradesAsync(input, token);
        }

        public async Task<DataCode> HeadsAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.HeadsInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.HeadsAsync with version {version}");

            return Map<IType, DataCode>(
                await _client.ParasStorage.HeadsAsync(input, token));
        }

        public async Task<BaseVec<Id>> ParachainsAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<Id>>(
                await _client.ParasStorage.ParachainsAsync(token));
        }

        public async Task<EnumParaLifecycle> ParaLifecyclesAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.ParaLifecyclesInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.ParaLifecyclesAsync with version {version}");

            return Map<IType, EnumParaLifecycle>(
                await _client.ParasStorage.ParaLifecyclesAsync(input, token));
        }

        public async Task<Hash> PastCodeHashAsync(BaseTuple<Id, U32> key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);

            var input = (IBaseEnumerable)_mapper.Map(version, key, _client.ParasStorage.PastCodeHashInputType(version));


            return Map<IType, Hash>(await _client.ParasStorage.PastCodeHashAsync(input, token));
        }

        public async Task<ParaPastCodeMeta> PastCodeMetaAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.PastCodeMetaInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.PastCodeMetaAsync with version {version}");

            return Map<IType, ParaPastCodeMeta>(
                await _client.ParasStorage.PastCodeMetaAsync(input, token));
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
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.UpcomingParasGenesisInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.UpcomingParasGenesisAsync with version {version}");

            return Map<IType, ParaGenesisArgs>(
                await _client.ParasStorage.UpcomingParasGenesisAsync(input, token));
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
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.UpgradeGoAheadSignalInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.UpgradeGoAheadSignalAsync with version {version}");

            return Map<IType, EnumUpgradeGoAhead>(
                await _client.ParasStorage.UpgradeGoAheadSignalAsync(input, token));
        }

        public async Task<EnumUpgradeRestriction> UpgradeRestrictionSignalAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.ParasStorage.UpgradeRestrictionSignalInputType(version));

            Guard.Against.Null(input, $"Unable to get input type from _client.ParasStorage.UpgradeRestrictionSignalAsync with version {version}");

            return Map<IType, EnumUpgradeRestriction>(
                await _client.ParasStorage.UpgradeRestrictionSignalAsync(input, token));
        }
    }
}
