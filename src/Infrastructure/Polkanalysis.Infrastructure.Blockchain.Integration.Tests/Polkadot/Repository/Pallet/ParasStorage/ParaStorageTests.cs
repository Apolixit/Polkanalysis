﻿using Substrate.NetApi.Model.Types.Base;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.ParasStorage
{
    public class ParaStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task Parachains_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Paras.ParachainsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value, Is.Not.Null);
        }

        [Test]
        public async Task ParaLifecycles_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Paras.ParaLifecyclesAsync(new Id(2094), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Heads_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Paras.HeadsAsync(new Id(2094), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CurrentCodeHash_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Paras.CurrentCodeHashAsync(new Id(2094), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task PastCodeMeta_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Paras.PastCodeMetaAsync(new Id(2094), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Category(NoTestCase), Ignore(NoTestCase)]
        public async Task CodeByHash_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Paras.CodeByHashAsync(new Hash("0x9c900905bf8cb084be9ce07bfc122857071f81d53142b25f5fea04986e5d79ab"), CancellationToken.None);
            Assert.That(res, Is.Null);
        }

        [Test, Category(NoTestCase), Ignore(NoTestCase)]
        public async Task CodeByHashRefs_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Paras.CodeByHashRefsAsync(new Hash("0x9c900905bf8cb084be9ce07bfc122857071f81d53142b25f5fea04986e5d79ab"), CancellationToken.None);
            Assert.That(res, Is.Null);
        }
    }
}
