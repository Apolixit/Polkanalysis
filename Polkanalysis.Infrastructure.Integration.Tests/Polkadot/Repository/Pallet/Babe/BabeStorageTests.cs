using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Babe
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
        public async Task PendingEpochConfigChange_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.PendingEpochConfigChangeAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task EpochConfig_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.EpochConfigAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task NextEpochConfig_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.NextEpochConfigAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Randomness_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.RandomnessAsync(CancellationToken.None);
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
