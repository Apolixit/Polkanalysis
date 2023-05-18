﻿using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Authorship
{
    public class AuthorshipStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task Author_ShouldWorkAsync()
        {
            var res = await _substrateRepository.At("0x70e500784bdec5d7f4299aab1a24d47998b1b0d764ca25c12c3c7bb15b66aad1").Storage.Authorship.AuthorAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Uncles_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Authorship.UnclesAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task DidSetUncles_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Authorship.DidSetUnclesAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
