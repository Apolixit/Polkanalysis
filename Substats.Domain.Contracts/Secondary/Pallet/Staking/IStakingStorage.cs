using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public interface IStakingStorage
    {
        /// <summary>
        /// The ideal number of active validators.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> ValidatorCountAsync(CancellationToken token);

        /// <summary>
        /// Minimum number of staking participants before emergency conditions are imposed.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> MinimumValidatorCountAsync(CancellationToken token);

        /// <summary>
        ///  Any validators that may never be slashed or forcibly kicked. It's a Vec since they're
        ///  easy to initialize and the performance hit is minimal (we expect no more than four
        ///  invulnerables) and restricted to testnets.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IEnumerable<SubstrateAccount>> InvulnerablesAsync(CancellationToken token);

        /// <summary>
        /// Map from all locked "stash" accounts to the controller account.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SubstrateAccount> BondedAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// The minimum active bond to become and maintain the role of a nominator.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> MinNominatorBondAsync(CancellationToken token);

        /// <summary>
        /// The minimum active bond to become and maintain the role of a validator.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> MinValidatorBondAsync(CancellationToken token);

        /// <summary>
        ///  The minimum amount of commission that validators can set.
        /// 
        ///  If set to `0`, no limit exists.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Perbill> MinCommissionAsync(CancellationToken token);

        /// <summary>
        /// Map from all (unlocked) "controller" accounts to the info regarding the staking.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<StakingLedger> LedgerAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// Where the reward payment should be made. Keyed by stash.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<EnumRewardDestination> PayeeAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// The map from (wannabe) validator stash key to the preferences of that validator.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ValidatorPrefs> ValidatorsAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> CounterForValidatorsAsync(CancellationToken token);

        /// <summary>
        ///  The maximum validator count before we stop allowing new validators to join.
        /// 
        ///  When this value is not set, no limits are enforced. 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> MaxValidatorsCountAsync(CancellationToken token);

        /// <summary>
        ///  The map from nominator stash key to their nomination preferences, namely the validators that
        ///  they wish to support.
        /// 
        ///  Note that the keys of this storage map might become non-decodable in case the
        ///  [`Config::MaxNominations`] configuration is decreased. In this rare case, these nominators
        ///  are still existent in storage, their key is correct and retrievable (i.e. `contains_key`
        ///  indicates that they exist), but their value cannot be decoded. Therefore, the non-decodable
        ///  nominators will effectively not-exist, until they re-submit their preferences such that it
        ///  is within the bounds of the newly set `Config::MaxNominations`.
        /// 
        ///  This implies that `::iter_keys().count()` and `::iter().count()` might return different
        ///  values for this map. Moreover, the main `::count()` is aligned with the former, namely the
        ///  number of keys that exist.
        /// 
        ///  Lastly, if any of the nominators become non-decodable, they can be chilled immediately via
        ///  [`Call::chill_other`] dispatchable by anyone.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Nominations> NominatorsAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> CounterForNominatorsAsync(CancellationToken token);

        /// <summary>
        ///  The maximum nominator count before we stop allowing new validators to join.
        /// 
        ///  When this value is not set, no limits are enforced.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> MaxNominatorsCountAsync(CancellationToken token);

        /// <summary>
        ///  The current era index.
        /// 
        ///  This is the latest planned era, depending on how the Session pallet queues the validator
        ///  set, it might be active or not.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> CurrentEraAsync(CancellationToken token);

        /// <summary>
        ///  The active era information, it holds index and start.
        /// 
        ///  The active era is the era being currently rewarded. Validator set of this era must be
        ///  equal to [`SessionInterface::validators`].
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ActiveEraInfo> ActiveEraAsync(CancellationToken token);

        /// <summary>
        ///  The session index at which the era start for the last `HISTORY_DEPTH` eras.
        /// 
        ///  Note: This tracks the starting session (i.e. session index when era start being active)
        ///  for the eras in `[CurrentEra - HISTORY_DEPTH, CurrentEra]`.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> ErasStartSessionIndexAsync(uint key, CancellationToken token);

        /// <summary>
        ///  Exposure of validator at era.
        /// 
        ///  This is keyed first by the era index to allow bulk deletion and then the stash account.
        /// 
        ///  Is it removed after `HISTORY_DEPTH` eras.
        ///  If stakers hasn't been set or has been removed then empty exposure is returned.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Exposure> ErasStakersAsync((uint, SubstrateAccount) key, CancellationToken token);

        /// <summary>
        ///  Clipped Exposure of validator at era.
        /// 
        ///  This is similar to [`ErasStakers`] but number of nominators exposed is reduced to the
        ///  `T::MaxNominatorRewardedPerValidator` biggest stakers.
        ///  (Note: the field `total` and `own` of the exposure remains unchanged).
        ///  This is used to limit the i/o cost for the nominator payout.
        /// 
        ///  This is keyed fist by the era index to allow bulk deletion and then the stash account.
        /// 
        ///  Is it removed after `HISTORY_DEPTH` eras.
        ///  If stakers hasn't been set or has been removed then empty exposure is returned.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Exposure> ErasStakersClippedAsync((uint, SubstrateAccount) key, CancellationToken token);

        /// <summary>
        ///  Similar to `ErasStakers`, this holds the preferences of validators.
        /// 
        ///  This is keyed first by the era index to allow bulk deletion and then the stash account.
        /// 
        ///  Is it removed after `HISTORY_DEPTH` eras.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ValidatorPrefs> ErasValidatorPrefsAsync((uint, SubstrateAccount) key, CancellationToken token);

        /// <summary>
        ///  The total validator era payout for the last `HISTORY_DEPTH` eras.
        /// 
        ///  Eras that haven't finished yet or has been removed doesn't have reward.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> ErasValidatorRewardAsync(uint key, CancellationToken token);

        /// <summary>
        ///  Rewards for the last `HISTORY_DEPTH` eras.
        ///  If reward hasn't been set or has been removed then 0 reward is returned.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<EraRewardPoints> ErasRewardPointsAsync(uint key, CancellationToken token);

        /// <summary>
        ///  The total amount staked for the last `HISTORY_DEPTH` eras.
        ///  If total hasn't been set or has been removed then 0 stake is returned.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> ErasTotalStakeAsync(uint key, CancellationToken token);

        /// <summary>
        /// Mode of era forcing.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Forcing> ForceEraAsync(CancellationToken token);

        /// <summary>
        ///  The percentage of the slash that is distributed to reporters.
        /// 
        ///  The rest of the slashed value is handled by the `Slash`.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Perbill> SlashRewardFractionAsync(CancellationToken token);

        /// <summary>
        ///  The amount of currency given to reporters of a slash event which was canceled by extraordinary circumstances (e.g. governance).
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> CanceledSlashPayoutAsync(CancellationToken token);

        /// <summary>
        /// All unapplied slashes that are queued for later.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IEnumerable<UnappliedSlash>> UnappliedSlashesAsync(uint key, CancellationToken token);

        /// <summary>
        ///  A mapping from still-bonded eras to the first session index of that era.
        /// 
        ///  Must contains information for eras for the range:
        ///  `[active_era - bounding_duration; active_era]`
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IDictionary<uint, uint>> BondedErasAsync(CancellationToken token);

        /// <summary>
        ///  All slashing events on validators, mapped by era to the highest slash proportion
        ///  and slash value of the era.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<(Perbill, BigInteger)> ValidatorSlashInEraAsync((uint, SubstrateAccount) key, CancellationToken token);

        /// <summary>
        /// All slashing events on nominators, mapped by era to the highest slash value of the era.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> NominatorSlashInEraAsync((uint, SubstrateAccount) key, CancellationToken token);

        /// <summary>
        /// Slashing spans for stash accounts.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SlashingSpans> SlashingSpansAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        ///  Records information about the maximum slash of a stash within a slashing span,
        ///  as well as how much reward has been paid out.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SpanRecord> SpanSlashAsync((SubstrateAccount, uint) key, CancellationToken token);

        /// <summary>
        ///  The last planned session scheduled by the session pallet.
        /// 
        ///  This is basically in sync with the call to [`pallet_session::SessionManager::new_session`].
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<uint> CurrentPlannedSessionAsync(CancellationToken token);

        /// <summary>
        ///  Indices of validators that have offended in the active era and whether they are currently
        ///  disabled.
        /// 
        ///  This value should be a superset of disabled validators since not all offences lead to the
        ///  validator being disabled (if there was no slash). This is needed to track the percentage of
        ///  validators that have offended in the current era, ensuring a new era is forced if
        ///  `OffendingValidatorsThreshold` is reached. The vec is always kept sorted so that we can find
        ///  whether a given validator has previously offended using binary search. It gets cleared when
        ///  the era ends.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IDictionary<uint, bool>> OffendingValidatorsAsync(CancellationToken token);

        /// <summary>
        ///  True if network has been upgraded to this version.
        ///  Storage version of the pallet.
        /// 
        ///  This is set to v7.0.0 for new networks.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Releases> StorageVersionAsync(CancellationToken token);

        /// <summary>
        ///  The threshold for when users can start calling `chill_other` for other validators /
        ///  nominators. The threshold is compared to the actual number of validators / nominators
        ///  (`CountFor*`) in the system compared to the configured max (`Max*Count`).
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Percent> ChillThresholdAsync(CancellationToken token);
    }
}
