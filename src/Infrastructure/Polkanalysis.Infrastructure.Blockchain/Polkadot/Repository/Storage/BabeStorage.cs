using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using BabeStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.BabeStorage;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Sp;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    /// <summary>
    /// Babe storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="PolkadotMapping.BabeStorageProfile"/>
    /// </summary>
    public class BabeStorage : MainStorage, IBabeStorage
    {
        public BabeStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BaseVec<BaseTuple<PublicSr25519, U64>>> AuthoritiesAsync(CancellationToken token)
        {
            var res = await _client.BabeStorage.AuthoritiesAsync(token);
            return Map<IBaseEnumerable, BaseVec<BaseTuple<PublicSr25519, U64>>>(res);
        }

        public async Task<BaseOpt<Hexa>> AuthorVrfRandomnessAsync(CancellationToken token)
        {
            return Map<IBaseValue, BaseOpt<Hexa>>(await _client.BabeStorage.AuthorVrfRandomnessAsync(token));
        }

        public async Task<BabeEpochConfiguration> EpochConfigAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.BabeEpochConfigurationBase, BabeEpochConfiguration>(await _client.BabeStorage.EpochConfigAsync(token));
        }

        public async Task<U64> EpochIndexAsync(CancellationToken token)
        {
            return await _client.BabeStorage.EpochIndexAsync(token);
        }

        public async Task<BaseTuple<U32, U32>> EpochStartAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseTuple<U32, U32>>(await _client.BabeStorage.EpochStartAsync(token));
        }

        public async Task<BaseOpt<EnumPreDigest>> InitializedAsync(CancellationToken token)
        {
            return Map<IBaseValue, BaseOpt<EnumPreDigest>>(await _client.BabeStorage.InitializedAsync(token));
        }

        public async Task<U32> LatenessAsync(CancellationToken token)
        {
            return await _client.BabeStorage.LatenessAsync(token);
        }

        public async Task<BaseVec<BaseTuple<PublicSr25519, U64>>> NextAuthoritiesAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseTuple<PublicSr25519, U64>>>(await _client.BabeStorage.NextAuthoritiesAsync(token));
        }

        public async Task<BabeEpochConfiguration> NextEpochConfigAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.BabeEpochConfigurationBase, BabeEpochConfiguration>(await _client.BabeStorage.NextEpochConfigAsync(token));
        }

        public async Task<Hexa> NextRandomnessAsync(CancellationToken token)
        {
            return Map<Arr32U8, Hexa>(await _client.BabeStorage.NextRandomnessAsync(token));
        }

        public async Task<EnumNextConfigDescriptor> PendingEpochConfigChangeAsync(CancellationToken token)
        {
            return Map<IBaseEnum, EnumNextConfigDescriptor>(await _client.BabeStorage.PendingEpochConfigChangeAsync(token));
        }

        public async Task<Hexa> RandomnessAsync(CancellationToken token)
        {
            return Map<Arr32U8, Hexa>(await _client.BabeStorage.RandomnessAsync(token));
        }

        public async Task<U32> SegmentIndexAsync(CancellationToken token)
        {
            return await _client.BabeStorage.SegmentIndexAsync(token);
        }

        public async Task<BaseVec<BaseTuple<U64, U32>>> SkippedEpochsAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseTuple<U64, U32>>>(await _client.BabeStorage.SkippedEpochsAsync(token));
        }

        public async Task<BaseVec<Hexa>> UnderConstructionAsync(U32 key, CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<Hexa>>(await _client.BabeStorage.UnderConstructionAsync(key, token));
        }

        public async Task<Slot> CurrentSlotAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase, Slot>(await _client.BabeStorage.CurrentSlotAsync(token));
        }

        public async Task<Slot> GenesisSlotAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase, Slot>(await _client.BabeStorage.GenesisSlotAsync(token));
        }
    }
}
