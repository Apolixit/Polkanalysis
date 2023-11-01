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

        [Test]
        [Category("NO_DATA")]
        public async Task Account_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount("13b9d23v1Hke7pcVk8G4gh3TBckDtrwFZUnqPkHezq4praEY");
            var res = await _substrateRepository.At("0xb00b97e5f34bf0b92770a3cd8a23f56ff3c48422e05a68e51cd8f94f2cdd3d72").Storage.Balances.AccountAsync(testAccount, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Locks_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS");
            var res = await _substrateRepository.Storage.Balances.LocksAsync(testAccount, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [Category("NO_DATA")]
        public async Task Reserves_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS");
            var res = await _substrateRepository.Storage.Balances.ReservesAsync(testAccount, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
