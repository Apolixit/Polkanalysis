using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.PeopleChain.Pallet.Balances
{
    internal class BalancesStorageTests : PeopleChainIntegrationTests
    {
        [Test, Ignore("No test case")]
        public async Task InactiveIssuance_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Balances.InactiveIssuanceAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task TotalIssuance_ShouldWorkAsync()
        {
            var res = await _substrateService.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore("Todo debug")]
        [TestCase(710328, "13Jpq4n3PXXaSAbJTMmFD78mXAzs8PzgUUQd5ve8saw7HQS5")]
        public async Task Account_ShouldWorkAsync(int numBlock, string accountAddress)
        {
            var testAccount = new SubstrateAccount(accountAddress);
            var res1 = await _substrateService.At(numBlock).Storage.Balances.AccountAsync(testAccount, CancellationToken.None);

            Assert.That(res1, Is.Not.Null);
        }

        [Test, Ignore("No test case")]
        [TestCase(639396, "13UVJyLnbVp8c4FQeiGG4wgZ8fTPB4dJZ21YasxCzie2jyC3")]
        public async Task Locks_ShouldWorkAsync(int blockNumber, string accountAddress)
        {
            var res = await _substrateService.At(blockNumber).Storage.Balances.LocksAsync(new SubstrateAccount(accountAddress), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value.Length, Is.GreaterThan(0));
        }

        [Test, Ignore("No test case")]
        [TestCase(22495153, "13Q48Ep3PVpvXA1BeVcUhNJerLshsaeq4EdgPUHnemqJYmND")] // block 	22495152 - balances (Reserved) events on this account
        public async Task Reserves_ShouldWorkAsync(int blockNumber, string accountAddress)
        {
            var res = await _substrateService.At(blockNumber).Storage.Balances.ReservesAsync(new SubstrateAccount(accountAddress), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore("No test case")]
        [TestCase(639396)]
        public async Task InactiveIssuanceAsync_ShouldWorkAsync(int numBlock)
        {
            var res = await _substrateService.At(numBlock).Storage.Balances.InactiveIssuanceAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore("No test case")]
        [TestCase(22495160, "16DKyH4fggEXeGwCytqM19e9NFGkgR2neZPDJ5ta8BKpPbPK")]
        public async Task HoldsAsync_ShouldWorkAsync(int blockNumber, string accountAddress)
        {
            var res = await _substrateService.At(blockNumber).Storage.Balances.HoldsAsync(new SubstrateAccount(accountAddress), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore("No test case")]
        [TestCase(22406190, "13UVJyLnbVp8c4FQeiGWPxJyYv51Y4TxbNNc7RgSVnSduy7E")] // block 	22406183 - balances (Frozen) events on this account
        public async Task FreezesAsync_ShouldWorkAsync(int blockNumber, string accountAddress)
        {
            var res = await _substrateService.At(blockNumber).Storage.Balances.FreezesAsync(new SubstrateAccount(accountAddress), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
