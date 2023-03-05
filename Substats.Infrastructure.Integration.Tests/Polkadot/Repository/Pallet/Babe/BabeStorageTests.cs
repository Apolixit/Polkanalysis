﻿using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core.Random;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Babe
{
    public class BabeStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task Authorities_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.AuthoritiesAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value.Length, Is.GreaterThan(1));
        }

        [Test]
        public async Task AuthorVrfRandomness_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.AuthorVrfRandomnessAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task CurrentSlot_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.CurrentSlotAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task EpochConfig_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.EpochConfigAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task NextRandomness_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.NextRandomnessAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task UnderConstruction_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.UnderConstructionAsync(new U32(0), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Initialized_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.InitializedAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}