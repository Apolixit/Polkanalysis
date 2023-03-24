using Ajuna.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Balances.Enums;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.Balances
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
        public async Task AccountData_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount("13b9d23v1Hke7pcVk8G4gh3TBckDtrwFZUnqPkHezq4praEY");
            var res = await _substrateRepository.Storage.Balances.AccountAsync(testAccount, CancellationToken.None);
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
