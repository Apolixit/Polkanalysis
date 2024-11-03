using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Identity
{
    public class IdentityStorageTests : PolkadotIntegrationTest
    {
        [Test]
        [TestCase(22666089, "14Xh9F14w9GPwprsytsXd9nCpf9VvjAUTg5Mj7zN2SU8RBDj")] // Call PeopleChain
        [TestCase(21556495, "14Xh9F14w9GPwprsytsXd9nCpf9VvjAUTg5Mj7zN2SU8RBDj")]
        [TestCase(17794701, "1v8nuDB4ChEumFThaj7sSySR88nBDmViBJfvhWA2zqmtvY3")]
        public async Task IdentityOfAt_ShouldWorkAsync(int blockNum, string address)
        {
            var res = await _substrateService.At(blockNum).Storage.Identity.IdentityOfAsync(new SubstrateAccount(address), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase("14Xh9F14w9GPwprsytsXd9nCpf9VvjAUTg5Mj7zN2SU8RBDj")]
        public async Task IdentityOf_ShouldWorkAsync(string address)
        {
            var res = await _substrateService.Storage.Identity.IdentityOfAsync(new SubstrateAccount(address), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(22666089, "1REAJ1k691g5Eqqg9gL7vvZCBG7FCCZ8zgQkZWd4va5ESih")]
        [TestCase(21556495, "1REAJ1k691g5Eqqg9gL7vvZCBG7FCCZ8zgQkZWd4va5ESih")]
        public async Task SubsOf_ShouldWorkAsync(int blockNum, string address)
        {
            var res = await _substrateService.At(blockNum).Storage.Identity.SubsOfAsync(new SubstrateAccount(address), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore("No data")]
        [TestCase(22666089, "168MQ9ZFvQb9Hoe68Vg2Ji5xYuqSmf4agaD5epVnGWaKM2oK")]
        [TestCase(21556495, "168MQ9ZFvQb9Hoe68Vg2Ji5xYuqSmf4agaD5epVnGWaKM2oK")]
        public async Task SuperOf_ShouldWorkAsync(int blockNum, string address)
        {
            var res = await _substrateService.At(blockNum).Storage.Identity.SuperOfAsync(new SubstrateAccount(address), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(22666089)]
        [TestCase(21556495)]
        public async Task Registrars_ShouldWorkAsync(int blockNum)
        {
            var res = await _substrateService.At(blockNum).Storage.Identity.RegistrarsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
