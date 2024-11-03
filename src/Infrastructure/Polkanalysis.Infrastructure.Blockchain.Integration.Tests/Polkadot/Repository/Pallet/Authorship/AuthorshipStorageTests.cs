using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Authorship
{
    public class AuthorshipStorageTests : PolkadotIntegrationTest
    {
        [Test, Category(NoTestCase)]
        public async Task Author_ShouldWorkAsync()
        {
            var res = await _substrateService.At("0x70e500784bdec5d7f4299aab1a24d47998b1b0d764ca25c12c3c7bb15b66aad1").Storage.Authorship.AuthorAsync(CancellationToken.None);
            Assert.That(res, Is.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task Uncles_ShouldWorkAsync()
        {
            var res = await _substrateService.At(12220000).Storage.Authorship.UnclesAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase)]
        public async Task DidSetUncles_ShouldWorkAsync()
        {
            var res = await _substrateService.At(12220000).Storage.Authorship.DidSetUnclesAsync(CancellationToken.None);
            Assert.That(res, Is.Null);
        }
    }
}
