using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Primitive;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Ajuna.NetApi.Model.Types;
using System.Transactions;

namespace Blazscan.Domain.Tests.Node
{
    public class NodeTest
    {
        [Test]
        public void CreateNode_ShouldBeEmpty()
        {
            var newNode = new EventNode();
            Assert.IsTrue(newNode.IsEmpty);
        }

        [Test]
        public void CreateNode_WithAmount_ShouldSucceed()
        {
            var node = new EventNode();
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
            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(addressAccount));

            //Amount
            var u32Amount = new U32();
            u32Amount.Create(1000);

            var nodeAccount = new EventNode();
            nodeAccount.AddData(accountId32);
            nodeAccount.AddHumanData(addressAccount);
            nodeAccount.AddName("from");
            Assert.IsTrue(nodeAccount.IsLeaf);

            var nodeAmount = new EventNode();
            nodeAmount.AddData(u32Amount);
            nodeAmount.AddHumanData(u32Amount.Value);
            nodeAmount.AddName("amount");
            Assert.IsTrue(nodeAmount.IsLeaf);


            var masterNode = new EventNode();
            Assert.IsEmpty(masterNode.Children);

            masterNode.AddChild(nodeAccount);
            masterNode.AddChild(nodeAmount);
            masterNode.AddName("transaction");

            Assert.IsNotEmpty(masterNode.Children);
            var jsonResult = @"{""transaction"":[{""from"":""5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY""},{""amount"":1000}]}";
            Assert.That(masterNode.ToJson(), Is.EqualTo(jsonResult));
        }
    }
}
