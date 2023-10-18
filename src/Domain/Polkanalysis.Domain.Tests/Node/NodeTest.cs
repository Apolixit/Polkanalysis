﻿using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.SystemCore.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.SystemCore;

namespace Polkanalysis.Domain.Tests.Node
{
    public class NodeTest
    {
        [Test]
        public void CreateNode_ShouldBeEmpty()
        {
            var newNode = new GenericNode();
            Assert.IsTrue(newNode.IsEmpty);
        }

        [Test]
        public void CreateNode_WithAmount_ShouldSucceed()
        {
            var node = new GenericNode();
            var u32Amount = new U32();
            u32Amount.Create(1000);

            node.AddData(u32Amount);
            Assert.That(node.Data, Is.EqualTo(u32Amount));

            Assert.IsFalse(node.IsEmpty);

            node.AddHumanData(u32Amount.Value);
            Assert.That(node.HumanData, Is.EqualTo(u32Amount.Value));

            var name = "amount";
            node.AddName(name);
            Assert.That(node.Name, Is.EqualTo(name));

            var jsonResult = @"{" +
                "\"amount\":1000" +
                "}";
            Assert.That(node.ToJson(), Is.EqualTo(jsonResult));

        }

        [Test]
        public void CreateNode_WithChildrenDepth1_ShouldSucceed()
        {
            //Account
            var addressAccount = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY";
            var accountId32 = new SubstrateAccount(addressAccount);

            //Amount
            var u32Amount = new U32();
            u32Amount.Create(1000);

            var nodeAccount = new GenericNode();
            nodeAccount.AddData(accountId32);
            nodeAccount.AddHumanData(addressAccount);
            nodeAccount.AddName("from");
            Assert.IsTrue(nodeAccount.IsLeaf);

            var nodeAmount = new GenericNode();
            nodeAmount.AddData(u32Amount);
            nodeAmount.AddHumanData(u32Amount.Value);
            nodeAmount.AddName("amount");
            Assert.IsTrue(nodeAmount.IsLeaf);


            var masterNode = new GenericNode();
            Assert.IsEmpty(masterNode.Children);

            masterNode.AddChild(nodeAccount);
            masterNode.AddChild(nodeAmount);
            masterNode.AddName("transaction");

            Assert.IsNotEmpty(masterNode.Children);
            var jsonResult = @"{""transaction"":[{""from"":""5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY""},{""amount"":1000}]}";
            Assert.That(masterNode.ToJson(), Is.EqualTo(jsonResult));
        }

        [Test]
        [TestCase("0x00010000000000384A7AFE72000000020000")]
        [Ignore("To JSON debug")]
        public void CreateNode_EventTimestamp_ShouldBeParsedToJson(string hex)
        {
            var decode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());

            //var enumTimestamp = new EnumRuntimeEvent();
            //enumTimestamp.Create(hex);
            var ev = new EventRecord();
            ev.Create(hex);
            var nodeResult = decode.Decode(ev);

            var json = nodeResult.ToJson();
            Assert.That(json, Is.Not.Null);
            //{ "":[{ "Phase":[{ "ApplyExtrinsic":[{ "":1}]}]},{ "Event":[{ "System":[{ "ExtrinsicSuccess":[{ "Weight":[{ "RefTime":[{ "":493895699000}]}]},{ "Class":[{ "":"Mandatory"}]},{ "PaysFee":[{ "":"Yes"}]}]}]}]},{ "Topics":null}]}

            //            {
            //            phase:
            //                {
            //                ApplyExtrinsic: 1
            //            }
            //    event: {
            //        method: ExtrinsicSuccess
            //        section: system
            //        index: 0x0000
            //      data:
            //            {
            //            dispatchInfo:
            //                {
            //                weight: 493,895,699,000
            //          class: Mandatory
            //          paysFee: Yes
            //    }
            //}
            //    }
            //    topics: []
            //  }
        }

        [Test]
        [Ignore("To JSON debug")]
        [TestCase("0x26aa394eea5630e07c48ae0c9558cef7b99d880ec681799c0cf30e8886371da942a9602fb314fb8ece26eb5e685d5d95e45dda4a3ac186e2ac54d8aed98db9dbdfff54087b96414057ad263ca02bfb96")]
        public void CreateNode_AccountInfo_ShouldBeParsedToJson(string hex)
        {
            var decode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());

            var accountInfo = new AccountInfo();
            accountInfo.Create(hex);
            var nodeResult = decode.Decode(accountInfo);

            var json = nodeResult.ToJson();
            Assert.That(json, Is.Not.Null);

            // System.account > FrameSystemAccountInfo
            //{
            //        nonce: 1
            //  consumers: 2
            //  providers: 1
            //  sufficients: 0
            //  data: {
            //    free: 216,381,979,941
            //    reserved: 0
            //    miscFrozen: 200,000,000,000
            //    feeFrozen: 200,000,000,000
            //  }
            //}
        }
    }
}
