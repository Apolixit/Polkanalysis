using Ajuna.NetApi.Model.Types.Primitive;
using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Staking;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class StakingStorage : IStakingStorage
    {
        private readonly SubstrateClientExt _client;
        public StakingStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<ActiveEraInfo> ActiveEraAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SubstrateAccount> BondedAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<U32, U32>> BondedErasAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> CanceledSlashPayoutAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Percent> ChillThresholdAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForNominatorsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CounterForValidatorsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CurrentEraAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CurrentPlannedSessionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<EraRewardPoints> ErasRewardPointsAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Exposure> ErasStakersAsync((U32, SubstrateAccount) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Exposure> ErasStakersClippedAsync((U32, SubstrateAccount) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> ErasStartSessionIndexAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> ErasTotalStakeAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ValidatorPrefs> ErasValidatorPrefsAsync((U32, SubstrateAccount) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> ErasValidatorRewardAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Forcing> ForceEraAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubstrateAccount>> InvulnerablesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<StakingLedger> LedgerAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> MaxNominatorsCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> MaxValidatorsCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Perbill> MinCommissionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> MinimumValidatorCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> MinNominatorBondAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> MinValidatorBondAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Nominations> NominatorsAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U128> NominatorSlashInEraAsync((U32, SubstrateAccount) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<U32, Bool>> OffendingValidatorsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<EnumRewardDestination> PayeeAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SlashingSpans> SlashingSpansAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Perbill> SlashRewardFractionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<SpanRecord> SpanSlashAsync((SubstrateAccount, U32) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Releases> StorageVersionAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UnappliedSlash>> UnappliedSlashesAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> ValidatorCountAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ValidatorPrefs> ValidatorsAsync(SubstrateAccount account, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<(Perbill, U128)> ValidatorSlashInEraAsync((U32, SubstrateAccount) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
