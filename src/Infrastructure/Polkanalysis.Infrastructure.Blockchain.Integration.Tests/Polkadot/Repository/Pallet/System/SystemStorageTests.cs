﻿using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using System.Threading;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.System
{
    public class SystemStorageTests : PolkadotIntegrationTest
    {
        [Test]
        //[TestCase(1, "12H7nsDUrJUSCQQJrTKAFfyCWSactiSdjoVUixqcd9CZHTGt"), Ignore("Todo manage metadata prev v14")]
        [TestCase(18112436, "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        public async Task Account_ShouldWorkAsync(int numBlock, string accountAddress)
        {
            var res = await _substrateRepository.At(numBlock).Storage.System.AccountAsync(
                new SubstrateAccount(accountAddress),
                CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public async Task GetAllAccounts_ShouldWorkAsync(int nb)
        {
            var query = await _substrateRepository.Storage.System.AccountsQueryAsync(CancellationToken.None);
            var res = await query.Take(nb).ExecuteAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.LessThanOrEqualTo(nb));

            var addressAccount = res.Select(x => x.Item1.ToStringAddress());
            Assert.That(addressAccount.Distinct().Count(), Is.EqualTo(res.Count));
        }

        [Test, Ignore("Todo debug")]
        [TestCase(100)]
        public async Task GetAllAccounts_FromSpecificHashShouldWorkAsync(int nb)
        {
            var query = await _substrateRepository.At("0x8AC682A247013A2EA8EB3623B4D2E7B2AEC2DF09B57E9F42D6A91AD9F2362F2C").Storage.System.AccountsQueryAsync(CancellationToken.None);
            var res = await query.Take(nb).ExecuteAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.LessThanOrEqualTo(nb));

            var addressAccount = res.Select(x => x.Item1.ToStringAddress());
            Assert.That(addressAccount.Distinct().Count(), Is.EqualTo(res.Count));
        }

        [Test]
        public async Task Number_ShouldWorkAsync()
        {
            var blockNum = await _substrateRepository.Storage.System.NumberAsync(CancellationToken.None);
            Assert.That(blockNum, Is.Not.Null);
            Assert.That(blockNum.Value, Is.GreaterThan(0));
        }

        [Test]
        public async Task BlockWeight_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.BlockWeightAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore(NoTestCase)]
        public async Task BlockHash_ShouldWorkAsync()
        {
            var blockData = await _substrateRepository.Rpc.Chain.GetBlockAsync(CancellationToken.None);
            var res = await _substrateRepository.Storage.System.BlockHashAsync(new U32((uint)blockData.Block.Header.Number.Value), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task ExtrinsicData_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.ExtrinsicDataAsync(new U32(1), CancellationToken.None);

            Assert.That(res, Is.Null);
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
        public async Task EventsAt_ShouldWorkAsync()
        {
            // 18,112,436 -> 18,112,443
            var res = await _substrateRepository.At(18112436).Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Events_ShouldWorkAsync()
        {
            var res = await _substrateRepository.At(20127534).Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore(NoTestCase)]
        public async Task EventTopics_ShouldWorkAsync()
        {
            //var res = await _substrateRepository.Storage.System.EventTopicsAsync(CancellationToken.None);

            //Assert.That(res, Is.Not.Null);
            Assert.Fail();
        }

        [Test]
        public async Task LastRuntimeUpgrade_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.LastRuntimeUpgradeAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task ExecutionPhase_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.System.ExecutionPhaseAsync(CancellationToken.None);

            Assert.That(res, Is.Null);
        }

        [Test]
        public async Task GetMetadata_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Rpc.State.GetMetaDataAsync(Utils.HexToByteArray("0x82fbb5fb09611ed2f999415275b53033d8b368ffa2ebd5d3dbeb7e094cbb09c0"), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
