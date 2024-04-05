using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Crowdloan
{
    public class CrowdloanStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task EndingsCount_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Crowdloan.EndingsCountAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Funds_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Crowdloan.FundsAsync(new Id(2094), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task FundsAll_ShouldWorkAsync()
        {
            var query = await _substrateRepository.Storage.Crowdloan.FundsQueryAsync(CancellationToken.None);
            var res = await query.ExecuteAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.GreaterThan(2));
        }

        [Test, Category(NoTestCase)]
        public async Task NewRaise_ShouldWorkAsync()
        {
            _ = await _substrateRepository.Storage.Crowdloan.NewRaiseAsync(CancellationToken.None);

            // Just want to be sure that I don't get an exception
            Assert.Pass();
        }

        [Test]
        public async Task NewRaise_FromGivenBock_ShouldWorkAsync()
        {
            var res = await _substrateRepository.At(20215034).Storage.Crowdloan.NewRaiseAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value[0].Value.Value, Is.EqualTo((uint)2011));
            Assert.That(res.Value[1].Value.Value, Is.EqualTo((uint)3368));
            Assert.That(res.Value[2].Value.Value, Is.EqualTo((uint)3356));
            Assert.That(res.Value[3].Value.Value, Is.EqualTo((uint)3359));
        }
    }
}
