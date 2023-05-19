using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.NominationPools
{
    public class NominationPoolsStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task PoolMembers_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.PoolMembersAsync(
                new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task PoolMembersAll_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.PoolMembersAllAsync(CancellationToken.None);
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
        public async Task BondedPoolsAll_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.NominationPools.BondedPoolsAllAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
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
                new U32(1), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
