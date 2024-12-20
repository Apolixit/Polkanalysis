﻿using Substrate.NetApi.Model.Types.Base;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Random;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Session
{
    public class SessionStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task Validators_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Session.ValidatorsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task QueuedKeys_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Session.QueuedKeysAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task NextKeys_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Session.NextKeysAsync(new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS"), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore(NoTestCase)]
        public async Task KeyOwner_ShouldWorkAsync()
        {
            var i2 = new FlexibleNameable().FromText("gran");
            var input = new BaseTuple<FlexibleNameable, Hexa32>();
            input.Create(i2, new Hexa32("0xf26945a8a64032a1defa76e720a99649125b55751b6088205e7acab901de670b"));

            var res = await _substrateService.Storage.Session.KeyOwnerAsync(input, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
