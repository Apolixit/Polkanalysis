﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using StakingStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.StakingStorage;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class StakingStorage : MainStorage, IStakingStorage
    {
        public StakingStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<ActiveEraInfo> ActiveEraAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.ActiveEraInfo,
                ActiveEraInfo>
                (StakingStorageExt.ActiveEraParams, token);
        }

        public async Task<SubstrateAccount> BondedAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                AccountId32,
                SubstrateAccount>(PolkadotMapping.Instance.Map<AccountId32>(account), StakingStorageExt.BondedParams, token);
        }

        public async Task<BaseVec<BaseTuple<U32, U32>>> BondedErasAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<BaseTuple<U32, U32>>>
                (StakingStorageExt.BondedErasParams, token);
        }

        public async Task<U128> CanceledSlashPayoutAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(StakingStorageExt.CanceledSlashPayoutParams, token);
        }

        public async Task<Percent> ChillThresholdAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Percent,
                Percent>(StakingStorageExt.ChillThresholdParams, token);
        }

        public async Task<U32> CounterForNominatorsAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.CounterForNominatorsParams, token);
        }

        public async Task<U32> CounterForValidatorsAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.CounterForValidatorsParams, token);
        }

        public async Task<U32> CurrentEraAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.CurrentEraParams, token);
        }

        public async Task SubscribeNewCurrentEraAsync(Action<U32> callbackEra, CancellationToken token)
        {
            await SubscribeToAsync(StakingStorageExt.CurrentEraParams(), callbackEra, token);
        }

        public async Task<U32> CurrentPlannedSessionAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.CurrentPlannedSessionParams, token);
        }

        public async Task<EraRewardPoints> ErasRewardPointsAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EraRewardPoints,
                EraRewardPoints>(key, StakingStorageExt.ErasRewardPointsParams, token);
        }

        public async Task<Exposure> ErasStakersAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
               BaseTuple<U32, AccountId32>,
               Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Exposure,
               Exposure>(PolkadotMapping.Instance.Map<BaseTuple<U32, AccountId32>>(key), StakingStorageExt.ErasStakersParams, token);
        }

        //public async Task<BaseTuple<BaseTuple<U32, SubstrateAccount>, Exposure>> ErasStakersAsync(U32 key, CancellationToken token)
        //{
        //    return await GetStorageWithParamsAsync<
        //       U32,
        //       BaseTuple<BaseTuple<U32, AccountId32>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Exposure>,
        //       BaseTuple<BaseTuple<U32, SubstrateAccount>, Exposure>>(key, ErasStakersParams, token);
        //}
        public QueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure> ErasStakersQuery(uint eraId)
        {
            var x = ErasStakersParams(new U32(1080));
            return new QueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure>(
                GetAllStorageAsync<BaseTuple<U32, AccountId32>,
                BaseTuple<U32, SubstrateAccount>,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Exposure,
                Exposure>, "Staking", "ErasStakers", ErasStakersParams(new U32(eraId)), 36);
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
            return await GetStorageWithParamsAsync<
               BaseTuple<U32, AccountId32>,
               Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Exposure,
               Exposure>(PolkadotMapping.Instance.Map<BaseTuple<U32, AccountId32>>(key), StakingStorageExt.ErasStakersClippedParams, token);
        }

        public async Task<U32> ErasStartSessionIndexAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<U32, U32>(key, StakingStorageExt.ErasStartSessionIndexParams, token);
        }

        public async Task<U128> ErasTotalStakeAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<U32, U128>(key, StakingStorageExt.ErasTotalStakeParams, token);
        }

        public async Task<ValidatorPrefs> ErasValidatorPrefsAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
               BaseTuple<U32, AccountId32>,
               Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.ValidatorPrefs,
               ValidatorPrefs>(PolkadotMapping.Instance.Map<BaseTuple<U32, AccountId32>>(key), StakingStorageExt.ErasValidatorPrefsParams, token);
        }

        public async Task<U128> ErasValidatorRewardAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<U32, U128>(key, StakingStorageExt.ErasValidatorRewardParams, token);
        }

        public async Task<EnumForcing> ForceEraAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumForcing, EnumForcing>(StakingStorageExt.ForceEraParams, token);
        }

        public async Task<BaseVec<SubstrateAccount>> InvulnerablesAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<AccountId32>, BaseVec<SubstrateAccount>>(StakingStorageExt.InvulnerablesParams, token);
        }

        public async Task<StakingLedger> LedgerAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.StakingLedger,
                StakingLedger>(PolkadotMapping.Instance.Map<AccountId32>(account), StakingStorageExt.LedgerParams, token);
        }

        public async Task<U32> MaxNominatorsCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.MaxNominatorsCountParams, token);
        }

        public async Task<U32> MaxValidatorsCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.MaxValidatorsCountParams, token);
        }

        public async Task<Perbill> MinCommissionAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill, Perbill
                >(StakingStorageExt.MinCommissionParams, token);
        }

        public async Task<U32> MinimumValidatorCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.MinimumValidatorCountParams, token);
        }

        public async Task<U128> MinNominatorBondAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(StakingStorageExt.MinNominatorBondParams, token);
        }

        public async Task<U128> MinValidatorBondAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(StakingStorageExt.MinValidatorBondParams, token);
        }

        public async Task<Nominations> NominatorsAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Nominations,
                Nominations>(PolkadotMapping.Instance.Map<AccountId32>(account), StakingStorageExt.NominatorsParams, token);
        }

        public QueryStorage<SubstrateAccount, Nominations> NominatorsQuery()
        {
            return new QueryStorage<SubstrateAccount, Nominations>(
                GetAllStorageAsync<AccountId32, SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Nominations, Nominations>, "Staking", "Nominators");
        }

        public async Task<U128> NominatorSlashInEraAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                BaseTuple<U32, AccountId32>,
                U128>(
                PolkadotMapping.Instance.Map<BaseTuple<U32, AccountId32>>(key), StakingStorageExt.NominatorSlashInEraParams, token);
        }

        public async Task<BaseVec<BaseTuple<U32, Bool>>> OffendingValidatorsAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseVec<BaseTuple<U32, Bool>>>(StakingStorageExt.OffendingValidatorsDefault, token);
        }

        public async Task<EnumRewardDestination> PayeeAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumRewardDestination,
                EnumRewardDestination>(
                PolkadotMapping.Instance.Map<AccountId32>(account), StakingStorageExt.PayeeParams, token);
        }

        public async Task<SlashingSpans> SlashingSpansAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.slashing.SlashingSpans,
                SlashingSpans>(
                PolkadotMapping.Instance.Map<AccountId32>(account), StakingStorageExt.SlashingSpansParams, token);
        }

        public async Task<Perbill> SlashRewardFractionAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill, Perbill
                >(StakingStorageExt.SlashRewardFractionParams, token);
        }

        public async Task<SpanRecord> SpanSlashAsync(BaseTuple<SubstrateAccount, U32> key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                BaseTuple<AccountId32, U32>,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.slashing.SpanRecord,
                SpanRecord>(
                PolkadotMapping.Instance.Map<BaseTuple<AccountId32, U32>>(key), StakingStorageExt.SpanSlashParams, token);
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
            return await GetStorageAsync<U128>(StakingStorageExt.MinimumActiveStakeParams, token);
        }

        public async Task<BaseVec<UnappliedSlash>> UnappliedSlashesAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.UnappliedSlash>,
                BaseVec<UnappliedSlash>>(key, StakingStorageExt.UnappliedSlashesParams, token);
        }

        public async Task<U32> ValidatorCountAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(StakingStorageExt.ValidatorCountParams, token);
        }

        public async Task<ValidatorPrefs> ValidatorsAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.ValidatorPrefs,
                ValidatorPrefs
                >(PolkadotMapping.Instance.Map<AccountId32>(account), StakingStorageExt.ValidatorsParams, token);
        }

        public async Task<BaseTuple<Perbill, U128>> ValidatorSlashInEraAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                BaseTuple<U32, AccountId32>,
                BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill, U128>,
                BaseTuple<Perbill, U128>
                >(PolkadotMapping.Instance.Map<BaseTuple<U32, AccountId32>>(key), StakingStorageExt.ValidatorSlashInEraParams, token);
        }
    }
}
