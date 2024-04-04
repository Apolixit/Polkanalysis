using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Runtime;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Staking
{
    public class StakingStorageTests : PolkadotIntegrationTest
    {
        private async Task<U32> GetLastFinishedEraAsync()
        {
            var era = await _substrateRepository.Storage.Staking.CurrentEraAsync(CancellationToken.None);

            return new U32(era.Value - 2);
        }

        private async Task<(U32, SubstrateAccount)> GetValidatorFromThisEraAsync()
        {
            var era = await _substrateRepository.Storage.Staking.CurrentEraAsync(CancellationToken.None);
            var query = await _substrateRepository.Storage.Staking.ErasStakersQueryAsync(era.Value, CancellationToken.None);
            var allValidators = await query.Take(2).ExecuteAsync(CancellationToken.None);

            var staker = allValidators.First().Item1.Value[1].As<SubstrateAccount>();
            Assert.That(staker, Is.Not.Null);

            return (era, staker);
        }

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
            var query = await _substrateRepository.Storage.Staking.NominatorsQueryAsync(CancellationToken.None);
            var allNominators = await query.Take(2).ExecuteAsync(CancellationToken.None);

            Assert.That(allNominators.Count, Is.GreaterThan(0));

            var res = await _substrateRepository.Storage.Staking.NominatorsAsync(allNominators.First().Item1, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(20)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public async Task NominatorsAll_ShouldWorkAsync(int nbTake)
        {
            var query = await _substrateRepository.Storage.Staking.NominatorsQueryAsync(CancellationToken.None);
            var res = await query.Take(nbTake).ExecuteAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.LessThanOrEqualTo(nbTake));

            var addressAccount = res.Select(x => x.Item1.ToStringAddress());
            Assert.That(addressAccount.Distinct().Count(), Is.EqualTo(res.Count));
        }

        [Test]
        [TestCase(10, 20)]
        [TestCase(1000, 1000)]
        public async Task NominatorsAll_WithAdvancedQuery_ShouldWorkAsync(int nbSkip, int nbTake)
        {
            var query = await _substrateRepository.Storage.Staking.NominatorsQueryAsync(CancellationToken.None);
            var res = await query.Skip(nbSkip).Take(nbTake).ExecuteAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.LessThanOrEqualTo(nbTake));

            var addressAccount = res.Select(x => x.Item1.ToStringAddress());
            Assert.That(addressAccount.Distinct().Count(), Is.EqualTo(res.Count));
        }

        [Test]
        public async Task NominatorsAll_EnsurePaginationIsValidAsync()
        {
            var nominatorsQuery = await _substrateRepository.Storage.Staking.NominatorsQueryAsync(CancellationToken.None);
            var res_2000 = await nominatorsQuery.Take(2000).ExecuteAsync(CancellationToken.None);

            var res_1200_800 = await nominatorsQuery.Skip(1200).Take(800).ExecuteAsync(CancellationToken.None);

            Assert.That(res_2000[1200].Item2.Bytes, Is.EqualTo(res_1200_800.First().Item2.Bytes));
            Assert.That(res_2000.Last().Item2.Bytes, Is.EqualTo(res_1200_800.Last().Item2.Bytes));

            var res_15_20 = await nominatorsQuery.Skip(15).Take(20).ExecuteAsync(CancellationToken.None);
            var res_500_1500 = await nominatorsQuery.Skip(500).Take(1500).ExecuteAsync(CancellationToken.None);
            var res_3500 = await nominatorsQuery.Skip(3500).Take(1).ExecuteAsync(CancellationToken.None);

            Assert.That(res_2000.Count, Is.GreaterThanOrEqualTo(res_15_20.Count));
            Assert.That(res_500_1500.Count, Is.GreaterThanOrEqualTo(res_15_20.Count));
            Assert.That(res_15_20.Count, Is.GreaterThanOrEqualTo(res_3500.Count));

            Assert.That(res_2000[15].Item1.Bytes, Is.EqualTo(res_15_20.First().Item1.Bytes));
            Assert.That(res_2000[34].Item1.Bytes, Is.EqualTo(res_15_20.Last().Item1.Bytes));

            Assert.That(res_3500.Count, Is.EqualTo(1));
            Assert.That(res_500_1500.Last().Item1.Bytes, Is.EqualTo(res_1200_800.Last().Item1.Bytes));
        }

        [Test]
        public async Task CounterForNominators_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.CounterForNominatorsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task MaxNominatorsCount_ShouldWorkAsync()
        {
            //RequestGenerator.GetStorageKeyBytesHash("Staking", "MaxNominatorsCount");
            var res = await _substrateRepository.Storage.Staking.MaxNominatorsCountAsync(CancellationToken.None);
            Assert.That(res, Is.Null);
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
            var res = await _substrateRepository.Storage.Staking.ErasStartSessionIndexAsync(await GetLastFinishedEraAsync(), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasStakers_ShouldWorkAsync()
        {
            var (era, staker) = await GetValidatorFromThisEraAsync();

            var res = await _substrateRepository.Storage.Staking.ErasStakersAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasStakersAll_ShouldWorkAsync()
        {
            var currentEra = await _substrateRepository.Storage.Staking.CurrentEraAsync(CancellationToken.None);
            var nbValidators = await _substrateRepository.Storage.Staking.ValidatorCountAsync(CancellationToken.None);
            var query = await _substrateRepository.Storage.Staking.ErasStakersQueryAsync(currentEra.Value, CancellationToken.None);
            var res = await query.ExecuteAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.EqualTo(nbValidators.Value));
        }

        [Test, Category(NoTestCase)]
        public async Task ErasStakersClipped_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.ErasStakersClippedAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Null);
        }

        [Test]
        public async Task ErasValidatorPrefs_ShouldWorkAsync()
        {
            var (era, staker) = await GetValidatorFromThisEraAsync();
            var res = await _substrateRepository.Storage.Staking.ErasValidatorPrefsAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasValidatorReward_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ErasValidatorRewardAsync(
                await GetLastFinishedEraAsync(), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasRewardPoints_ShouldWorkAsync()
        {
            var era = await _substrateRepository.Storage.Staking.CurrentEraAsync(CancellationToken.None);
            var res = await _substrateRepository.Storage.Staking.ErasRewardPointsAsync(await GetLastFinishedEraAsync(), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ErasTotalStake_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ErasTotalStakeAsync(await GetLastFinishedEraAsync(), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task ForceEra_ShouldWorkAsync()
        {
            var req = Utils.Bytes2HexString(RequestGenerator.GetStorageKeyBytesHash("Staking", "ForceEra"));
            var res = await _substrateRepository.Storage.Staking.ForceEraAsync(CancellationToken.None);
            Assert.That(res, Is.Null);
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
            Assert.That(res, Is.Null);
        }

        [Test]
        public async Task BondedEras_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.BondedErasAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task ValidatorSlashInEra_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.ValidatorSlashInEraAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task NominatorSlashInEra_ShouldWorkAsync()
        {
            var era = new U32(981);
            var staker = new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS");

            var res = await _substrateRepository.Storage.Staking.NominatorSlashInEraAsync(new BaseTuple<U32, SubstrateAccount>(era, staker), CancellationToken.None);
            Assert.That(res, Is.Null);
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
            var res = await _substrateRepository.At(18111046).Storage.Staking.OffendingValidatorsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        //[Test]
        //[Ignore("Todo debug")]
        //public async Task StorageVersion_ShouldWorkAsync()
        //{
        //    var res = await _substrateRepository.Storage.Staking.StorageVersionAsync(CancellationToken.None);

        //    Assert.That(res, Is.Not.Null);
        //    Assert.That(res.Bytes, Is.Not.Null);
        //    Assert.That(res.Bytes.Length, Is.GreaterThan(0));
        //}

        [Test]
        public async Task ChillThreshold_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Staking.ChillThresholdAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
