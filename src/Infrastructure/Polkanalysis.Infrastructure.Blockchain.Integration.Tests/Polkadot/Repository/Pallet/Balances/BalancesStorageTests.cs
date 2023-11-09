using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Balances
{
    public class BalancesStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task InactiveIssuance_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Balances.InactiveIssuanceAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task TotalIssuance_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore(NoTestCase)]
        [TestCase("13UVJyLnbVp77Z2t6qvevjrhAHvhXzEKzVRLFA8VLSMjLCw7")]
        public async Task Account_ShouldWorkAsync(string accountAddress)
        {
            var testAccount = new SubstrateAccount(accountAddress);
            var res1 = await _substrateRepository.At("0xb00b97e5f34bf0b92770a3cd8a23f56ff3c48422e05a68e51cd8f94f2cdd3d72").Storage.Balances.AccountAsync(testAccount, CancellationToken.None);

            Assert.That(res1, Is.Not.Null);

            var res2 = await _substrateRepository.At("0x05c4845d91ee84d795c725491c07f7fb5b6adc5fcae209c3ac7dcfc80913cb72").Storage.Balances.AccountAsync(testAccount, CancellationToken.None);
            Assert.That(res2, Is.Not.Null);
        }

        [Test, Ignore(NoTestCase)]
        public async Task Locks_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS");
            var res = await _substrateRepository.Storage.Balances.LocksAsync(testAccount, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [Ignore(NoTestCase)]
        public async Task Reserves_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS");
            var res = await _substrateRepository.Storage.Balances.ReservesAsync(testAccount, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
