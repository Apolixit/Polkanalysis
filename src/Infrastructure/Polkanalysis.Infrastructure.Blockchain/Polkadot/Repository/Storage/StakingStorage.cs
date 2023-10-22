using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class StakingStorage : MainStorage, IStakingStorage
    {
        public StakingStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<ActiveEraInfo> ActiveEraAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ActiveEraInfoBase, ActiveEraInfo>(
                await _client.StakingStorage.ActiveEraAsync(token));
        }

        public async Task<SubstrateAccount> BondedAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base, SubstrateAccount>(
                await _client.StakingStorage.BondedAsync(accountId32, token));
        }

        public async Task<BaseVec<BaseTuple<U32, U32>>> BondedErasAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseTuple<U32, U32>>>(await _client.StakingStorage.BondedErasAsync(token));
        }

        public async Task<U128> CanceledSlashPayoutAsync(CancellationToken token)
        {
            return await _client.StakingStorage.CanceledSlashPayoutAsync(token);
        }

        public async Task<Percent> ChillThresholdAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PercentBase, Percent>(
                await _client.StakingStorage.ChillThresholdAsync(token));
        }

        public async Task<U32> CounterForNominatorsAsync(CancellationToken token)
        {
            return await _client.StakingStorage.CounterForNominatorsAsync(token);
        }

        public async Task<U32> CounterForValidatorsAsync(CancellationToken token)
        {
            return await _client.StakingStorage.CounterForValidatorsAsync(token);
        }

        public async Task<U32> CurrentEraAsync(CancellationToken token)
        {
            return await _client.StakingStorage.CurrentEraAsync(token);
        }

        public async Task SubscribeNewCurrentEraAsync(Action<U32> callbackEra, CancellationToken token)
        {
            await SubscribeToAsync(RequestGenerator.GetStorage("Staking", "CurrentEra", Substrate.NetApi.Model.Meta.Storage.Type.Plain), callbackEra, token);
        }

        public async Task<U32> CurrentPlannedSessionAsync(CancellationToken token)
        {
            return await _client.StakingStorage.CurrentPlannedSessionAsync(token);
        }

        public async Task<EraRewardPoints> ErasRewardPointsAsync(U32 key, CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.EraRewardPointsBase, EraRewardPoints>(
                await _client.StakingStorage.ErasRewardPointsAsync(key, token));
        }

        public async Task<Exposure> ErasStakersAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var val = await MapWithVersionAsync<BaseTuple<U32, SubstrateAccount>, IBaseEnumerable>(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ExposureBase, Exposure>(
                await _client.StakingStorage.ErasStakersAsync(val, token));
        }

        public QueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure> ErasStakersQuery(uint eraId)
        {
            //return new QueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure>(
            //    GetAllStorageAsync<BaseTuple<U32, AccountId32>,
            //    BaseTuple<U32, SubstrateAccount>,
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Exposure,
            //    Exposure>, "Staking", "ErasStakers", ErasStakersParams(new U32(eraId)), 36);
            throw new NotImplementedException();
        }
        private static string ErasStakersParams(U32 key)
        {
            return RequestGenerator.GetStorage("Staking", "ErasStakers", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                                Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat
                }, new Substrate.NetApi.Model.Types.IType[] {
                                            key
            });
        }


        public async Task<Exposure> ErasStakersClippedAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var val = await MapWithVersionAsync<BaseTuple<U32, SubstrateAccount>, IBaseEnumerable>(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ExposureBase, Exposure>(
                await _client.StakingStorage.ErasStakersClippedAsync(val, token));
        }

        public async Task<U32> ErasStartSessionIndexAsync(U32 key, CancellationToken token)
        {
            return await _client.StakingStorage.ErasStartSessionIndexAsync(key, token);
        }

        public async Task<U128> ErasTotalStakeAsync(U32 key, CancellationToken token)
        {
            return await _client.StakingStorage.ErasTotalStakeAsync(key, token);
        }

        public async Task<ValidatorPrefs> ErasValidatorPrefsAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var val = await MapWithVersionAsync<BaseTuple<U32, SubstrateAccount>, IBaseEnumerable>(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ValidatorPrefsBase, ValidatorPrefs>(
                await _client.StakingStorage.ErasValidatorPrefsAsync(val, token));
        }

        public async Task<U128> ErasValidatorRewardAsync(U32 key, CancellationToken token)
        {
            return await _client.StakingStorage.ErasValidatorRewardAsync(key, token);
        }

        public async Task<EnumForcing> ForceEraAsync(CancellationToken token)
        {
            return Map<IBaseEnum, EnumForcing>(await _client.StakingStorage.ForceEraAsync(token));
        }

        public async Task<BaseVec<SubstrateAccount>> InvulnerablesAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<SubstrateAccount>>(await _client.StakingStorage.InvulnerablesAsync(token));
        }

        public async Task<StakingLedger> LedgerAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.StakingLedgerBase, StakingLedger>(
                await _client.StakingStorage.LedgerAsync(accountId32, token));
        }

        public async Task<U32> MaxNominatorsCountAsync(CancellationToken token)
        {
            return await _client.StakingStorage.MaxNominatorsCountAsync(token);
        }

        public async Task<U32> MaxValidatorsCountAsync(CancellationToken token)
        {
            return await _client.StakingStorage.MaxValidatorsCountAsync(token);
        }

        public async Task<Perbill> MinCommissionAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>(
                await _client.StakingStorage.MinCommissionAsync(token));
        }

        public async Task<U32> MinimumValidatorCountAsync(CancellationToken token)
        {
            return await _client.StakingStorage.MinimumValidatorCountAsync(token);
        }

        public async Task<U128> MinNominatorBondAsync(CancellationToken token)
        {
            return await _client.StakingStorage.MinNominatorBondAsync(token);
        }

        public async Task<U128> MinValidatorBondAsync(CancellationToken token)
        {
            return await _client.StakingStorage.MinValidatorBondAsync(token);
        }

        public async Task<Nominations> NominatorsAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.NominationsBase, Nominations>(
                await _client.StakingStorage.NominatorsAsync(accountId32, token));
        }

        public QueryStorage<SubstrateAccount, Nominations> NominatorsQuery()
        {
            //return new QueryStorage<SubstrateAccount, Nominations>(
            //    GetAllStorageAsync<AccountId32, SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Nominations, Nominations>, "Staking", "Nominators");
            throw new InvalidOperationException();
        }

        public async Task<U128> NominatorSlashInEraAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var val = await MapWithVersionAsync<BaseTuple<U32, SubstrateAccount>, IBaseEnumerable>(key, token);
            return await _client.StakingStorage.NominatorSlashInEraAsync(val, token);
        }

        public async Task<BaseVec<BaseTuple<U32, Bool>>> OffendingValidatorsAsync(CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<BaseTuple<U32, Bool>>>(await _client.StakingStorage.OffendingValidatorsAsync(token));
        }

        public async Task<EnumRewardDestination> PayeeAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IBaseEnum, EnumRewardDestination>(await _client.StakingStorage.PayeeAsync(accountId32, token));
        }

        public async Task<SlashingSpans> SlashingSpansAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing.SlashingSpansBase, SlashingSpans>(
                await _client.StakingStorage.SlashingSpansAsync(accountId32, token));
        }

        public async Task<Perbill> SlashRewardFractionAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>(
                await _client.StakingStorage.SlashRewardFractionAsync(token));
        }

        public async Task<SpanRecord> SpanSlashAsync(BaseTuple<SubstrateAccount, U32> key, CancellationToken token)
        {
            var val = await MapWithVersionAsync<BaseTuple<SubstrateAccount, U32>, IBaseEnumerable>(key, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing.SpanRecordBase, SpanRecord>(
                await _client.StakingStorage.SpanSlashAsync(val, token));
        }

        // Add versionning ?
        //public async Task<EnumReleases> StorageVersionAsync(CancellationToken token)
        //{
        //    return await GetStorageAsync<
        //        Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumReleases,
        //        EnumReleases>(StakingStorageExt.StorageVersionParams, token);
        //}

        public async Task<U128> MinimumActiveStakeAsync(CancellationToken token)
        {
            return await _client.StakingStorage.MinimumActiveStakeAsync(token);
        }

        public async Task<BaseVec<UnappliedSlash>> UnappliedSlashesAsync(U32 key, CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<UnappliedSlash>>(await _client.StakingStorage.UnappliedSlashesAsync(key, token));
        }

        public async Task<U32> ValidatorCountAsync(CancellationToken token)
        {
            return await _client.StakingStorage.ValidatorCountAsync(token);
        }

        public async Task<ValidatorPrefs> ValidatorsAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ValidatorPrefsBase, ValidatorPrefs>(
                await _client.StakingStorage.ValidatorsAsync(accountId32, token));
        }

        public async Task<BaseTuple<Perbill, U128>> ValidatorSlashInEraAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var val = await MapWithVersionAsync<BaseTuple<U32, SubstrateAccount>, IBaseEnumerable>(key, token);
            return Map<IBaseEnumerable, BaseTuple<Perbill, U128>>(await _client.StakingStorage.ValidatorSlashInEraAsync(val, token));
        }

        public async Task<U32> HistoryDepthAsync(CancellationToken token)
        {
            return await _client.StakingStorage.ValidatorCountAsync(token);
        }

        public async Task<EnumReleases> StorageVersionAsync(CancellationToken token)
        {
            return Map<IBaseEnum, EnumReleases>(await _client.StakingStorage.StorageVersionAsync(token));
        }
    }
}
