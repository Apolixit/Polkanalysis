using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Substrate.NetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Common
{
    public class SubstrateAccountTest
    {
        [Test]
        public void SubstrateAccount_FromAccountId32_ShouldCreate()
        {
            var account = new SubstrateAccount("5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y");

            Assert.Multiple(() => {
                Assert.That(account.ToPublicKey().ToLower(), Is.EqualTo("0x6a4e76d530fa715a95388b889ad33c1665062c3dec9bf0aca3a9e4ff45781e48".ToLower()));
                Assert.That(account.ToEthereumAddress().ToLower(), Is.EqualTo("0x6a4E76D530fa715a95388B889ad33c1665062C3d".ToLower()));
            });
            
        }

        [Test]
        public void SubstrateAccount_FromAccountId20_ShouldCreate()
        {
            var account = new SubstrateAccount("0x6f08Fb1fC80DE904a9026065E4d36c3a5AC06AEF");
            Assert.That(account.ToString().ToLower(), Is.EqualTo("13Waz2A924yWXTNDztwJMH6WNqWHKeMm9RP78giWRJ8Y6eNr".ToLower()));
        }

        [Test]
        public void SubstrateAccount20_FromUniversalAddress_ShouldCreate()
        {
            var account = new SubstrateAccount("13Waz2A924yWXTNDztwJMH6WNqWHKeMm9RP78giWRJ8Y6eNr");

            Assert.Multiple(() =>
            {
                Assert.That(account.ToPublicKey().ToLower(), Is.EqualTo("0x6f08fb1fc80de904a9026065e4d36c3a5ac06aef000000000000000000000000"));
                Assert.That(account.ToEthereumAddress().ToLower(), Is.EqualTo("0x6f08fb1fc80de904a9026065e4d36c3a5ac06aef"));
            });
            
        }
    }
}
