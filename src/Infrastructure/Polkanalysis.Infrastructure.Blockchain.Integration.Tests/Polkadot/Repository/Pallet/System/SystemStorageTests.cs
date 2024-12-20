﻿using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Substrate.NetApi;
using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using NSubstitute;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using System.Text;
using Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Common.Repository.Pallet.System;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.System
{
    public class SystemStorageTests : PolkadotIntegrationTest
    {
        protected ISubstrateDecoding _substrateDecoding = default!;

        [SetUp]
        public void Start()
        {
            _substrateDecoding = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(
                    _substrateService,
                    Substitute.For<ILogger<PalletBuilder>>()),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        public static IEnumerable<TestCaseData> AccountTestCases()
            => FilterTestCase(new List<TestCaseData>
            {
                new TestCaseData(14033244, "13gLE9RuaZ3vmZwVaZfsvPMNnTHPVhXKoMWjsNaP6F6ccA7s"),
                new TestCaseData(1, "12H7nsDUrJUSCQQJrTKAFfyCWSactiSdjoVUixqcd9CZHTGt"),
                new TestCaseData(29232, "12zSBXtK9evQRCG9Gsdr72RbqNzbNn2Suox2cTfugCLmWjqG"),
                new TestCaseData(188837, "12zSBXtK9evQRCG9Gsdr72RbqNzbNn2Suox2cTfugCLmWjqG"),
                new TestCaseData(199406, "15qomv8YFTpHrbiJKicP4oXfxRDyG4XEHZH7jdfJScnw2xnV"),
                new TestCaseData(214265, "146YJHyD5cjFN77HrfKhxUFbU8WjApwk9ncGD6NbxE66vhMS"),
                new TestCaseData(244359, "15qomv8YFTpHrbiJKicP4oXfxRDyG4XEHZH7jdfJScnw2xnV"),
                new TestCaseData(310000, "15qomv8YFTpHrbiJKicP4oXfxRDyG4XEHZH7jdfJScnw2xnV"),
                new TestCaseData(320000, "15qomv8YFTpHrbiJKicP4oXfxRDyG4XEHZH7jdfJScnw2xnV"),
                new TestCaseData(400000, "15qomv8YFTpHrbiJKicP4oXfxRDyG4XEHZH7jdfJScnw2xnV"),
                new TestCaseData(500000, "14wmQzDrWradDHGYaTmHo57Xuzj8bm7bUrKBYnp5TjcdPSG3"),
                new TestCaseData(600000, "14q4f6CVXWbn2x6si2VayXoZ85augv3nAuHZc1Kc2jeFNnPe"),
                new TestCaseData(700000, "13AtGSHJaDZrLHELmK6iKAuaAKHcetrH73N2KEb5M5SX1yDR"),
                new TestCaseData(750000, "15KDFYfFjdqhp3MDFEtHuyu9kLpXbT7k1zjx78MphViFdCaU"),
                new TestCaseData(790000, "12n8LvW7up8CPckXRFYdLTa1mUGEWviTJNVppznaQ2Uosywt"),
                new TestCaseData(800000, "14cxMDpBNLsNEXWyCzked3zghzaYWXwoqGT4h12GqQXdVhmn"),
                new TestCaseData(1300000, "14ShUZUYUR35RBZW6uVVt1zXDxmSQddkeDdXf1JkMA6P721N"),
                new TestCaseData(1700000, "14ianQU2g46wntbuJxx6u9cM6s8uvLngW1y9xKCcnejBHdTy"),
                new TestCaseData(1800000, "13pozTrjJ2KgPVu1spMsbGmqb6wnqf8wkchm64TU5GwZErta"),
                new TestCaseData(2400000, "136cybB7an16AkdtrzPbzPaFNcnf1Xs1YfczWGqXb5oaviYe"),
                new TestCaseData(2500000, "13YK1sHixcvVPc6v7q1F1p7e66dgoVjcSHnfv4cFJcuKbNke"),
                new TestCaseData(3700000, "12wtfs4UfodYT1Y6y8NQsQaduLSJbhz7oaNt1F6gTLFHD1y5"),
                new TestCaseData(3900000, "129fVMSrkbStWWpFfoKoS7DcPN8uNUYjNm55Au9atMq7AVnq"),
                new TestCaseData(4500000, "15KJ8D2WRTYP2ea9PQTPt6sChC8ZjLnAeLu6DBQdbQbVftPw"),
                new TestCaseData(5000000, "14YdhnrDRm3m73Qu5UP6qkzowsr9C6X4aSBL6saP7jAw4KyP"),
                new TestCaseData(6000000, "16ZzMovSVVLU5oP2o5PwNG2ybbdT2diiKPAsz6J37myEGsDw"),
                new TestCaseData(6500000, "13ougYD2SRkn88L14XiYCJc3mL7AzWoAMVdn1FwLumV49LjU"),
                new TestCaseData(7000000, "1zugcapKRuHy2C1PceJxTvXWiq6FHEDm2xa5XSU7KYP3rJE"),
                new TestCaseData(7220000, "12wvHR5rjguXaiN6FhQwXvWhmBtRURvsEoJUbnMPziZHKkBL"),
                new TestCaseData(7500000, "16DKyH4fggEXeGwCytqM19e9NFGkgR2neZPDJ5ta8BKpPbPK"),
                new TestCaseData(8000000, "1zugcacan4nrJ3HPBmiBgEn2XvRMbehqvmzSQXT3uLBDkh3"),
                new TestCaseData(8500000, "13BjZTpwEtPMcHrEbqxpgS8mz44cwv31UgyXoVM2uggSHKAT"),
                new TestCaseData(9000000, "15UtQRzd9oM2UznsAsfi6rRAh2oo5vjoXgeaqf8rJBKhnTrr"),
                new TestCaseData(9500000, "13mgD5oqo2XN3upmZLGJcenqq8Uzv55vYaWQmbFHMrhpjp5K"),
                new TestCaseData(10000000, "15MBzbxZeXFZxiTsMyvzKK7Hn4cqwHzC1QxT8uHYiYBWun3M"),
                new TestCaseData(10200000, "14DCwC1uGJjRdVLgqNbVkoGU8rooUx9WG7fWzC1Nn6g5yc5T"),
                new TestCaseData(10500000, "16SpacegeUTft9v3ts27CEC3tJaxgvE4uZeCctThFH3Vb24p"),
                new TestCaseData(10700000, "12HFymxpDmi4XXPHaEMp74CNpRhkqwG5qxnrgikkhon1XMrj"),
                new TestCaseData(10900000, "1zugcagDxgkJtPQ4cMReSwXUbhQPGgtDEmFdHaaoHAhkKhU"),
                new TestCaseData(11500000, "1xsSvZudWSgr65zhRzeHrHHKVzRizHMdbmDKGCkSD5UXJYE"),
                new TestCaseData(11900000, "12eZSMk8GJYE2Lq943dSEnMUoZs1ek7jU8QN3rEA1yPZPjcR"),
                new TestCaseData(12000000, "14Fqi7dFQfRtQRrtBW7BL5m9E1fbTp3dvAnW19AUqEKhWCFd"),
                new TestCaseData(12220000, "1nTfEEWASm1x6D16FPLLjPFC42Fb7Q5zLovrxQpPQe6j86s"),
                new TestCaseData(12400000, "168bhPTpsgByfKqM2pgUfZ2wPxQQpgTwxsA9iTV7vAN4wQiU"),
                new TestCaseData(12800000, "13BN4WksoyexwDWhGsMMUbU5okehD19GzdyqL4DMPR2KkQpP"),
                new TestCaseData(13000000, "1Ew5wAsMtvbRdd4RdxSheLpEkSRc718gtcfTv8EmgzEbknA"),
                new TestCaseData(13900000, "14DE8GdKnNvgoXCLFq62ZjNz2zsGqnxXBsRMwNpiPip2JSFJ"),
                new TestCaseData(14400000, "153Fz22gxQP8HM8RbnvEt9XWsXu9nR8jxZC2MbQFmuKhN62f"),
                new TestCaseData(15400000, "145MSC4N7BsnnXjunBjD7t5oKn6T2AR3T8Zi9zcupXUJoumC"),
                new TestCaseData(16400000, "1XQn94kWaMVJG16AWPKGmYFERfttsjZq4ompSTz2jxHK6uL"),
                new TestCaseData(16500000, "14d2kv44xf9nFnYdms32dYPKQsr5C9urbDzTz7iwU8iHb9az"),
                new TestCaseData(17907450, "168bhPTpsgByfKqM2pgUfZ2wPxQQpgTwxsA9iTV7vAN4wQiU"),
                new TestCaseData(18794175, "14g7XsFWsMpsPNkwQNhdHfsqKRehdRbpPLaGVTEhBe4Pt3Eu"),
                new TestCaseData(20029640, "16CmXwZbMu56nyYGqvqVjTaQhFpEtmuxuwF132BE4dd1QnoW"),
                new TestCaseData(20215034, "16ARoGkkDSTmeu9tDvfBDksu4qURGz6s1HSvXzrwGnsjFtKg"),
                new TestCaseData(20443970, "13TBraYSRLejaxxMqAYFQ87RNPoCy3c4LTE3Y7FKq4qcFEqf"),
                new TestCaseData(21318590, "1sAkfdTH3cHAdJRYqMPNdeV7GhTKrddvMfkQrm3pQBABWrN"),
                new TestCaseData(21460214, "11uMPbeaEDJhUxzU4ZfWW9VQEsryP9XqFcNRfPdYda6aFWJ"),
                new TestCaseData(21562434, "14x97B47NEi8v1dSBPYobQDwe44U5Xj5RGATWpihQCyXcSX4"),
                new TestCaseData(22422694, "16DKyH4fggEXeGwCytqM19e9NFGkgR2neZPDJ5ta8BKpPbPK"),
                new TestCaseData(18112436, "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS"),
            });

        [Test]
        [TestCaseSource(nameof(AccountTestCases))]
        public async Task Account_ShouldWorkAsync(int numBlock, string accountAddress)
        {
            var res = await _substrateService.At(numBlock).Storage.System.AccountAsync(
                new SubstrateAccount(accountAddress),
                CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(10000)]
        public async Task GetAllAccounts_ShouldWorkAsync(int nb)
        {
            await SystemStorageAbstractTests.GetAllAccounts_ShouldWorkAsync(_substrateService, nb);
        }

        [Test, Ignore("Todo debug")]
        [TestCase(100)]
        public async Task GetAllAccounts_FromSpecificHashShouldWorkAsync(int nb)
        {
            var query = await _substrateService.At("0x8AC682A247013A2EA8EB3623B4D2E7B2AEC2DF09B57E9F42D6A91AD9F2362F2C").Storage.System.AccountsQueryAsync(CancellationToken.None);
            var res = await query.Take(nb).ExecuteAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.LessThanOrEqualTo(nb));

            var addressAccount = res.Select(x => x.Item1.ToStringAddress());
            Assert.That(addressAccount.Distinct().Count(), Is.EqualTo(res.Count));
        }

        [Test]
        [TestCaseSource(nameof(BlockFromLast10Versions))]
        public async Task Number_ShouldWorkAsync(int block)
        {
            var blockNum = await _substrateService.At(block).Storage.System.NumberAsync(CancellationToken.None);
            Assert.That(blockNum, Is.Not.Null);
            Assert.That(blockNum.Value, Is.GreaterThan(0));
        }

        [Test]
        [TestCaseSource(nameof(BlockFromLast10Versions))]
        public async Task BlockWeight_ShouldWorkAsync(int block)
        {
            var res = await _substrateService.At(block).Storage.System.BlockWeightAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task BlockHash_ShouldWorkAsync()
        {
            var blockId = await _substrateService.Storage.System.NumberAsync(CancellationToken.None);
            var res = await _substrateService.Storage.System.BlockHashAsync(new U32(blockId - 10), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task ExtrinsicData_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.System.ExtrinsicDataAsync(new U32(1), CancellationToken.None);

            Assert.That(res, Is.Null);
        }

        [Test]
        [TestCaseSource(nameof(BlockFromLast10Versions))]
        public async Task ParentHash_ShouldWorkAsync(int block)
        {
            var res = await _substrateService.At(block).Storage.System.ParentHashAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(nameof(BlockFromLast10Versions))]
        public async Task Digest_ShouldWorkAsync(int block)
        {
            var res = await _substrateService.At(block).Storage.System.DigestAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        //[TestCaseSource(nameof(AllBlockVersionTestCases))]
        [TestCase(22666089)]
        [TestCase(1)]
        [TestCase(14007412)]
        [TestCase(20127534)]
        [TestCase(18112436)]
        public async Task EventsAt_ShouldWorkAsync(int blockNumber)
        {
            // 18,112,436 -> 18,112,443
            var res = await _substrateService.At(blockNumber).Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(22666089)]
        [CancelAfter(RepositoryMaxTimeout)]
        public async Task EventsAsNode_ShouldWorkAsync(int blockNumber)
        {
            var res = await _substrateService.At(blockNumber).Storage.System.EventsAsync(CancellationToken.None);
            var metadata = await _substrateService.At(blockNumber).GetMetadataAsync(CancellationToken.None).ConfigureAwait(false);

            var tasked = new List<Task<IEventNode>>();

            foreach (var ev in res.Value)
            {
                tasked.Add(_substrateDecoding.DecodeEventAsync(ev, metadata, CancellationToken.None));
            }

            await Task.WhenAll(tasked);
            foreach (var task in tasked)
            {
                var eventNode = await task;
                Assert.That((int)eventNode.Module, Is.GreaterThanOrEqualTo(0));
                Assert.That(eventNode.Method.ToString(), Is.Not.Empty);
                Assert.That(eventNode.EventData, Is.Not.Null);
                Assert.That(eventNode.EventData.IsLeaf, Is.False);
            }
        }

        [Test]
        [TestCase(20681308)]
        [CancelAfter(RepositoryMaxTimeout)]
        public async Task EventsAsNode_DebugBug_ShouldWorkAsync(int blockNumber)
        {
            var res = await _substrateService.At(blockNumber).Storage.System.EventsAsync(CancellationToken.None);
            var metadata = await _substrateService.At(blockNumber).GetMetadataAsync(CancellationToken.None);

            var decoded0 = await _substrateDecoding.DecodeEventAsync(res.Value[48], metadata, CancellationToken.None);
            var decoded = await _substrateDecoding.DecodeEventAsync(res.Value[49], metadata, CancellationToken.None);

            Assert.That((int)decoded.Module, Is.GreaterThan(0));
            Assert.That(decoded.Method.ToString(), Is.Not.Null);

            var json = decoded.ToParameterJson();
            Assert.That(json, Is.Not.Null);
        }

        [Test]
        public async Task ExtrinsicFailedAsNode_ShouldWorkAsync()
        {
            var res = await _substrateService.At(22666089).Storage.System.EventsAsync(CancellationToken.None);

            var eventNode = await _substrateDecoding.DecodeEventAsync(res.Value[56], CancellationToken.None);

            Assert.That(eventNode.Module.ToString(), Is.EqualTo("System"));
            Assert.That(eventNode.Method.ToString(), Is.EqualTo("ExtrinsicFailed"));
            Assert.That(eventNode["ExtrinsicFailed"], Is.Not.Null);

            Assert.That(eventNode["ExtrinsicFailed"][0].Name, Is.EqualTo("dispatch_error"));
            Assert.That(eventNode["ExtrinsicFailed"][0][0].Name, Is.EqualTo("Module"));
            Assert.That(eventNode["ExtrinsicFailed"][1].Name, Is.EqualTo("dispatch_info"));

            var json = eventNode.ToParameterJson();
            Assert.That(json, Is.Not.Null);
        }

        [Test]
        public async Task Events_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.System.EventsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore(NoTestCase)]
        public async Task EventTopics_ShouldWorkAsync()
        {
            //var res = await _substrateService.Storage.System.EventTopicsAsync(CancellationToken.None);

            //Assert.That(res, Is.Not.Null);
            Assert.Fail();
        }

        [Test]
        [TestCaseSource(nameof(AllBlockVersionTestCases))]
        public async Task LastRuntimeUpgrade_ShouldWorkAsync(int blockNumber)
        {
            var res = await _substrateService.At(blockNumber).Storage.System.LastRuntimeUpgradeAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task ExecutionPhase_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.System.ExecutionPhaseAsync(CancellationToken.None);

            Assert.That(res, Is.Null);
        }

        [Test]
        public async Task GetMetadata_ShouldWorkAsync()
        {
            var res = await _substrateService.Rpc.State.GetMetaDataAsync(Utils.HexToByteArray("0x82fbb5fb09611ed2f999415275b53033d8b368ffa2ebd5d3dbeb7e094cbb09c0"), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
