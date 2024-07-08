using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Ardalis.GuardClauses;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking;
using Substrate.NetApi.Model.Types;
using Substrate.NET.Utils;

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
            return Map<IType, BaseVec<BaseTuple<U32, U32>>>(await _client.StakingStorage.BondedErasAsync(token));
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
            return Map<EraRewardPointsBase, EraRewardPoints>(
                await _client.StakingStorage.ErasRewardPointsAsync(key, token));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Era Id / Validator account</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<Exposure> ErasStakersAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);

            if (version < 1002000U)
            {
                var input = _mapper.Map(version, key, _client.StakingStorage.ErasStakersInputType(version));
                return Map<IType, Exposure>(
                await _client.StakingStorage.ErasStakersAsync(input, token));
            }
            else
            {
                // https://github.com/polkadot-js/apps/issues/10004
                var eraStakerOverview = await ErasStakersOverviewAsync(key, token);

                for(uint i = 0; i < eraStakerOverview.PageCount!.Value; i++)
                {
                    var page = await ErasStakersPagedAsync(new BaseTuple<U32, SubstrateAccount, U32>(
                        key.Value[0].As<U32>(), 
                        key.Value[1].As<SubstrateAccount>(), 
                        new U32(i)), token);

                    if(eraStakerOverview.Others is null)
                        eraStakerOverview.Others = page.Others;
                    else
                        eraStakerOverview.Others = new BaseVec<IndividualExposure>(eraStakerOverview.Others.Value.Concat(page.Others.Value).ToArray());
                }

                return eraStakerOverview;
            }
        }

        /// <summary>
        /// Since version 1002000, the storage function has changed to ErasStakersOverview (https://github.com/polkadot-js/apps/issues/10004)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<Exposure> ErasStakersOverviewAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.StakingStorage.ErasStakersOverviewInputType(version));

            return Map<IType, Exposure>(
                await _client.StakingStorage.ErasStakersOverviewAsync(input, token));
        }

        /// <summary>
        /// Get nominators who vote for a validator in a specific era
        /// Since version 1002000 (previously, check "others" property from <see cref="Exposure" />)
        /// Works with <see cref="ErasStakersOverviewAsync" /> for Nominators pagination
        /// </summary>
        /// <param name="key">Era Id / Validator account / Page number</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ExposurePage> ErasStakersPagedAsync(BaseTuple<U32, SubstrateAccount, U32> key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = _mapper.Map(version, key, _client.StakingStorage.ErasStakersPagedInputType(version));

            return Map<IType, ExposurePage>(
                await _client.StakingStorage.ErasStakersPagedAsync(input, token));
        }

        public async Task<IQueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure>> ErasStakersQueryAsync(uint eraId, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var sourceKeyType = _client.StakingStorage.ErasStakersInputType(version);

            QueryStorageFunction? storageFunction = null;

            if (version < 1002000U)
            {
                storageFunction = new QueryStorageFunction("Staking", "ErasStakers", sourceKeyType, ExposureBase.TypeByVersion(version), 36, ErasStakersParams(new U32(eraId)));
            } else
            {
                storageFunction = new QueryStorageFunction("Staking", "ErasStakersOverview", sourceKeyType, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_staking.PagedExposureMetadataBase.TypeByVersion(version), 36, ErasStakersOverviewParams(new U32(eraId)));
            }

            return new QueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure>(GetAllStorageAsync<BaseTuple<U32, SubstrateAccount>, Exposure>, storageFunction);
        }
        private static string ErasStakersParams(U32 key)
        {
            return RequestGenerator.GetStorage("Staking", "ErasStakers", Substrate.NetApi.Model.Meta.Storage.Type.Map, [ Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat ], [ key ]);
        }
        private static string ErasStakersOverviewParams(U32 key)
        {
            return RequestGenerator.GetStorage("Staking", "ErasStakersOverview", Substrate.NetApi.Model.Meta.Storage.Type.Map, [ Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat ], [ key ]);
        }


        public async Task<Exposure> ErasStakersClippedAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = (IType)_mapper.Map(version, key, _client.StakingStorage.ErasStakersInputType(version));
            return Map<IType, Exposure>(
                await _client.StakingStorage.ErasStakersClippedAsync(input, token));
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
            var version = await GetVersionAsync(token);
            var input = (IType)_mapper.Map(version, key, _client.StakingStorage.ErasValidatorPrefsInputType(version));
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ValidatorPrefsBase, ValidatorPrefs>(
                await _client.StakingStorage.ErasValidatorPrefsAsync(input, token));
        }

        public async Task<U128> ErasValidatorRewardAsync(U32 key, CancellationToken token)
        {
            return await _client.StakingStorage.ErasValidatorRewardAsync(key, token);
        }

        public async Task<EnumForcing> ForceEraAsync(CancellationToken token)
        {
            return Map<IType, EnumForcing>(await _client.StakingStorage.ForceEraAsync(token));
        }

        public async Task<BaseVec<SubstrateAccount>> InvulnerablesAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<SubstrateAccount>>(await _client.StakingStorage.InvulnerablesAsync(token));
        }

        public async Task<StakingLedger> LedgerAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<StakingLedgerBase, StakingLedger>(
                await _client.StakingStorage.LedgerAsync(accountId32, token));
        }

        public async Task<U32?> MaxNominatorsCountAsync(CancellationToken token)
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

        public async Task<IQueryStorage<SubstrateAccount, Nominations>> NominatorsQueryAsync(CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var sourceKeyType = _client.StakingStorage.NominatorsInputType(version);
            var storageKeyType = NominationsBase.TypeByVersion(version);
            var storageFunction = new QueryStorageFunction("Staking", "Nominators", sourceKeyType, storageKeyType, 32);

            return new QueryStorage<SubstrateAccount, Nominations>(GetAllStorageAsync<SubstrateAccount, Nominations>, storageFunction);
        }

        public async Task<U128> NominatorSlashInEraAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = (IType)_mapper.Map(version, key, _client.StakingStorage.NominatorSlashInEraInputType(version));
            return await _client.StakingStorage.NominatorSlashInEraAsync(input, token);
        }

        public async Task<BaseVec<BaseTuple<U32, Bool>>?> OffendingValidatorsAsync(CancellationToken token)
        {
            return Map<IType, BaseVec<BaseTuple<U32, Bool>>>(await _client.StakingStorage.OffendingValidatorsAsync(token));
        }

        public async Task<EnumRewardDestination> PayeeAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IType, EnumRewardDestination>(await _client.StakingStorage.PayeeAsync(accountId32, token));
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
            Guard.Against.Null(key);

            var version = await GetVersionAsync(token);
            var input = (IType)_mapper.Map(version, key, _client.StakingStorage.SpanSlashInputType(version));
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing.SpanRecordBase, SpanRecord>(
                await _client.StakingStorage.SpanSlashAsync(input, token));
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

        public async Task<BaseVec<UnappliedSlash>?> UnappliedSlashesAsync(U32 key, CancellationToken token)
        {
            return Map<IType, BaseVec<UnappliedSlash>>(await _client.StakingStorage.UnappliedSlashesAsync(key, token));
        }

        public async Task<U32> ValidatorCountAsync(CancellationToken token)
        {
            return await _client.StakingStorage.ValidatorCountAsync(token);
        }

        public async Task<ValidatorPrefs> ValidatorsAsync(SubstrateAccount account, CancellationToken token)
        {
            ValidatorPrefsBase res = null;
            try
            {
                var accountId32 = await MapAccoundId32Async(account, token);
                res = await _client.StakingStorage.ValidatorsAsync(accountId32, token);
                var map = Map<ValidatorPrefsBase, ValidatorPrefs>(res);
                return map;
            } catch(Exception ex)
            {

            }
            return null;
        }

        public async Task<BaseTuple<Perbill, U128>?> ValidatorSlashInEraAsync(BaseTuple<U32, SubstrateAccount> key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var input = (IType)_mapper.Map(version, key, _client.StakingStorage.ValidatorSlashInEraInputType(version));

            return Map<IType, BaseTuple<Perbill, U128>>(await _client.StakingStorage.ValidatorSlashInEraAsync(input, token));
        }

        public async Task<U32> HistoryDepthAsync(CancellationToken token)
        {
            return await _client.StakingStorage.ValidatorCountAsync(token);
        }

        public async Task<EnumReleases> StorageVersionAsync(CancellationToken token)
        {
            return Map<IType, EnumReleases>(await _client.StakingStorage.StorageVersionAsync(token));
        }
    }
}
