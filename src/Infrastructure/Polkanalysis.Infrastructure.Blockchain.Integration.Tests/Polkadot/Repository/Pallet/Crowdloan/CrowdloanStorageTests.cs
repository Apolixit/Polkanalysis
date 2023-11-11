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
            var res = await _substrateRepository.Storage.Crowdloan.NewRaiseAsync(CancellationToken.None);
            Assert.That(res, Is.Null);
        }
    }
}
