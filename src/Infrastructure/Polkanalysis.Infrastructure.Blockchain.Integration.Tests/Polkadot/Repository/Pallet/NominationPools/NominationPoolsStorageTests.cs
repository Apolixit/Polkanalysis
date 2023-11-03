using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.NominationPools
{
    public class NominationPoolsStorageTests : PolkadotIntegrationTest
    {
        [Test]
        [TestCase("14bbKkUuXD7qpkn8TbbdVcMkeaAXUApuYU7bycv8R6kR9Wmh")]
        [TestCase("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        public async Task PoolMembers_ShouldWorkAsync(string address)
        {
            var x = Utils.GetPublicKeyFrom("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS");
            var s = new SubstrateAccount();
            s.Create(x);
            // 0xF6A27C9D9868B21FFD9F5220FE90872336419FF32C21ADBBD42232923EE0F301
            var res = await _substrateRepository.Storage.NominationPools.PoolMembersAsync(
                new SubstrateAccount(address), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task PoolMembersAll_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.PoolMembersQuery().ExecuteAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task BondedPools_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.BondedPoolsAsync(
                new U32(1), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task BondedPoolsQuery_ShouldWorkAsync()
        {
            var boundedPoolsQuery = _substrateRepository.Storage.NominationPools.BondedPoolsQuery();
            var res = await boundedPoolsQuery.ExecuteAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);

            //var res_10_10 = await boundedPoolsQuery.Skip(10).Take(10).ExecuteAsync(CancellationToken.None);
            var res_10_10 = await boundedPoolsQuery.ExecuteAsync(CancellationToken.None);
            Assert.That(res[10].Item1.Bytes, Is.EqualTo(res_10_10.First().Item1.Bytes));
            Assert.That(res[19].Item1.Bytes, Is.EqualTo(res_10_10.Last().Item1.Bytes));
        }

        [Test]
        public async Task BondedPoolsQuery_WithTooMuchSkip_ShouldReturnEmptyAsync()
        {
            var boundedPoolsQuery = _substrateRepository.Storage.NominationPools.BondedPoolsQuery();
            var res = await boundedPoolsQuery.Skip(1000).ExecuteAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task RewardPools_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.RewardPoolsAsync(
                new U32(1), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task SubPoolsStorage_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.SubPoolsStorageAsync(
                new U32(1), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Metadata_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.MetadataAsync(
                new U32(7), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CurrentVersion_ShouldWorkAsync()
        {
            // Pallet ID = 39
            var res = await _substrateRepository.Storage.NominationPools.PalletVersionAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CounterForSubPoolsStorage_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.CounterForSubPoolsStorageAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
