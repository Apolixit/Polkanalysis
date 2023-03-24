using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Substats.Domain.Contracts.Core;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Staking
{
    public class StakingStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task ValidatorCount_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ValidatorCountAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task MinimumValidatorCount_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.MinimumValidatorCountAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Invulnerables_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.InvulnerablesAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task MinNominatorBond_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.MinNominatorBondAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task MinValidatorBond_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.MinValidatorBondAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task MinCommission_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.MinCommissionAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [Ignore("Todo find substrate account")]
        public async Task Ledger_ShouldWorkAsync()
        {
            // TODO, find Ledger account
            var res = await _substrateRepository.Storage.Staking.LedgerAsync(new SubstrateAccount(""), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Payee_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.PayeeAsync(new SubstrateAccount("12mvRSJUwpf6VfWLmgEJjcQgzzh2bCTSvFDwrykmijdzqS5m"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Validators_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ValidatorsAsync(new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CounterForValidators_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.CounterForValidatorsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Nominators_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.NominatorsAsync(new SubstrateAccount("13bKbtzpWsJ1RN2choppMZButJyWb9CTtzn1Tq85JWe8Y8GN"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CounterForNominators_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.CounterForNominatorsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task MaxNominatorsCount_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.MaxNominatorsCountAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CurrentEra_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.CurrentEraAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ActiveEra_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ActiveEraAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasStartSessionIndex_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ErasStartSessionIndexAsync(new U32(981), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasStakers_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.ErasStakersAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasStakersClipped_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.ErasStakersClippedAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasValidatorPrefs_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.ErasValidatorPrefsAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasValidatorReward_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ErasValidatorRewardAsync(new U32(981), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasRewardPoints_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ErasRewardPointsAsync(new U32(959), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasTotalStake_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ErasTotalStakeAsync(new U32(959), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ForceEra_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ForceEraAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task SlashRewardFraction_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.SlashRewardFractionAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }


        [Test]
        public async Task CanceledSlashPayout_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.CanceledSlashPayoutAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task UnappliedSlashes_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.UnappliedSlashesAsync(new U32(959), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task BondedEras_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.BondedErasAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ValidatorSlashInEra_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.ValidatorSlashInEraAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task NominatorSlashInEra_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.NominatorSlashInEraAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task SlashingSpans_ShouldWorkAsync()
        {
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.SlashingSpansAsync(staker, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task SpanSlash_ShouldWorkAsync()
        {
            var staker = new SubstrateAccount("16UYgMXRP8pkgxQQ3sxxG7QaJuVR3kSPAo53BKH33LuggCwn");
            var index = new U32(0);

            var res = await _substrateRepository.Storage.Staking.SpanSlashAsync(new BaseTuple<SubstrateAccount, U32>(staker, index), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CurrentPlannedSession_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.CurrentPlannedSessionAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task OffendingValidators_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.OffendingValidatorsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [Ignore("Todo debug")]
        public async Task StorageVersion_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.StorageVersionAsync(CancellationToken.None);
            
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Bytes, Is.Not.Null);
            Assert.That(res.Bytes.Length, Is.GreaterThan(0));
        }

        [Test]
        public async Task ChillThreshold_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ChillThresholdAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
