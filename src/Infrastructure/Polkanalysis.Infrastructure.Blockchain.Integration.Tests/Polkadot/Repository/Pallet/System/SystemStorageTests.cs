using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.System
{
    public class SystemStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task Account_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.AccountAsync(new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS"), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public async Task GetAllAccounts_ShouldWorkAsync(int nb)
        {
            var res = await _substrateRepository.Storage.System.AccountsQuery().Take(nb).ExecuteAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.LessThanOrEqualTo(nb));

            var addressAccount = res.Select(x => x.Item1.ToStringAddress());
            Assert.That(addressAccount.Distinct().Count(), Is.EqualTo(res.Count));
        }

        [Test]
        public async Task BlockWeight_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.BlockWeightAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task BlockHash_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.BlockHashAsync(new U32(14548330), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ExtrinsicData_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.ExtrinsicDataAsync(new U32(1), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ParentHash_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.ParentHashAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Digest_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.DigestAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Events_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task EventTopics_ShouldWorkAsync()
        {
            //var res = await _substrateRepository.Storage.System.EventTopicsAsync(CancellationToken.None);

            //Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task LastRuntimeUpgrade_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.LastRuntimeUpgradeAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task ExecutionPhase_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.ExecutionPhaseAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task GetMetadata_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Rpc.State.GetMetaDataAtAsync("0x82fbb5fb09611ed2f999415275b53033d8b368ffa2ebd5d3dbeb7e094cbb09c0", CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
