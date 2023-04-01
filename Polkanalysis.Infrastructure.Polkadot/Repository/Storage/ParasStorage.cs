using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using ParasStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.ParasStorage;
using IdExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id;

namespace Polkanalysis.Infrastructure.Polkadot.Repository.Storage
{
    public class ParasStorage : MainStorage, IParasStorage
    {
        public ParasStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BaseVec<Id>> ActionsQueueAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                BaseVec<IdExt>,
                BaseVec<Id>>
                (key, ParasStorageExt.ActionsQueueParams, token);
        }

        public async Task<DataCode> CodeByHashAsync(Hash key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCode,
                DataCode>
                (PolkadotMapping.Instance.Map<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash>(key), ParasStorageExt.CodeByHashParams, token);
        }

        public async Task<U32> CodeByHashRefsAsync(Hash key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<                 Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash, 
                 U32>
                 (PolkadotMapping.Instance.Map<
                     Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash>(key), ParasStorageExt.CodeByHashRefsParams, token);
        }

        public async Task<Hash> CurrentCodeHashAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                 IdExt,
                 Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash,
                 Hash>
                 (PolkadotMapping.Instance.Map<
                     IdExt>(key), ParasStorageExt.CurrentCodeHashParams, token);
        }

        public async Task<Hash> FutureCodeHashAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                 IdExt,
                 Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash,
                 Hash>
                 (PolkadotMapping.Instance.Map<
                     IdExt>(key), ParasStorageExt.FutureCodeHashParams, token);
        }

        public async Task<U32> FutureCodeUpgradesAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                 IdExt,
                 U32>
                 (PolkadotMapping.Instance.Map<
                     IdExt>(key), ParasStorageExt.FutureCodeUpgradesParams, token);
        }

        public async Task<DataCode> HeadsAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                 IdExt,
                 Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HeadData,
                 DataCode>
                 (PolkadotMapping.Instance.Map<
                     IdExt>(key), ParasStorageExt.HeadsParams, token);
        }

        public async Task<BaseVec<Id>> ParachainsAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                 BaseVec<IdExt>,
                 BaseVec<Id>>
                 (ParasStorageExt.ParachainsParams, token);
        }

        public async Task<EnumParaLifecycle> ParaLifecyclesAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                 IdExt,
                 Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.EnumParaLifecycle,
                 EnumParaLifecycle>
                 (PolkadotMapping.Instance.Map<
                     IdExt>(key), ParasStorageExt.ParaLifecyclesParams, token);
        }

        public async Task<Hash> PastCodeHashAsync(BaseTuple<Id, U32> key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                BaseTuple<IdExt, U32>,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash,
                Hash>
                (PolkadotMapping.Instance.Map<BaseTuple<IdExt, U32>>(key), ParasStorageExt.PastCodeHashParams, token);
        }

        public async Task<ParaPastCodeMeta> PastCodeMetaAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                IdExt,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.ParaPastCodeMeta,
                ParaPastCodeMeta>
                (PolkadotMapping.Instance.Map<IdExt>(key), ParasStorageExt.PastCodeMetaParams, token);
        }

        public async Task<BaseVec<BaseTuple<Id, U32>>> PastCodePruningAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<BaseTuple<IdExt, U32>>,
                BaseVec<BaseTuple<Id, U32>>>
                (ParasStorageExt.PastCodePruningParams, token);
        }

        public async Task<BaseVec<Hash>> PvfActiveVoteListAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash>,
                BaseVec<Hash>>
                (ParasStorageExt.PvfActiveVoteListParams, token);
        }

        public async Task<PvfCheckActiveVoteState> PvfActiveVoteMapAsync(Hash key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.PvfCheckActiveVoteState,
                PvfCheckActiveVoteState>     (PolkadotMapping.Instance.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash>(key), ParasStorageExt.PvfActiveVoteMapParams, token);
        }

        public async Task<ParaGenesisArgs> UpcomingParasGenesisAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                IdExt,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.ParaGenesisArgs,
                ParaGenesisArgs>
                (PolkadotMapping.Instance.Map<IdExt>(key), ParasStorageExt.UpcomingParasGenesisParams, token);
        }

        public async Task<BaseVec<BaseTuple<Id, U32>>> UpcomingUpgradesAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<BaseTuple<IdExt, U32>>,
                BaseVec<BaseTuple<Id, U32>>
                >(ParasStorageExt.UpcomingUpgradesParams, token);
        }

        public async Task<BaseVec<BaseTuple<Id, U32>>> UpgradeCooldownsAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<BaseTuple<IdExt, U32>>,
                BaseVec<BaseTuple<Id, U32>>
                >(ParasStorageExt.UpgradeCooldownsParams, token);
        }

        public async Task<EnumUpgradeGoAhead> UpgradeGoAheadSignalAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                IdExt, 
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumUpgradeGoAhead,
                EnumUpgradeGoAhead>
                (PolkadotMapping.Instance.Map<IdExt>(key), ParasStorageExt.UpgradeGoAheadSignalParams, token);
        }

        public async Task<EnumUpgradeRestriction> UpgradeRestrictionSignalAsync(Id key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                IdExt,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumUpgradeRestriction,
                EnumUpgradeRestriction>
                (PolkadotMapping.Instance.Map<IdExt>(key), ParasStorageExt.UpgradeRestrictionSignalParams, token);
        }
    }
}
