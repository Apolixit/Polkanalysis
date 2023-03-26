using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Identity
{
    public class IdentityStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task IdentityOf_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Identity.IdentityOfAsync(new SubstrateAccount("1REAJ1k691g5Eqqg9gL7vvZCBG7FCCZ8zgQkZWd4va5ESih"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task SubsOf_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Identity.SubsOfAsync(new SubstrateAccount("1REAJ1k691g5Eqqg9gL7vvZCBG7FCCZ8zgQkZWd4va5ESih"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task SuperOf_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Identity.SuperOfAsync(new SubstrateAccount("14j3azi9gKGx2de7ADL3dkzZXFzTTUy1t3RND21PymHRXRp6"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Registrars_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Identity.RegistrarsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
