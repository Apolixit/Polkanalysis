using Substats.Domain.Contracts.Secondary;
using Substats.Integration.Tests.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Infrastructure.DirectAccess.Repository;
using Ajuna.NetApi;

namespace Substats.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Repository
{
    public class AccountRepositoryTest : PolkadotIntegrationTest
    {
        private IAccountRepository _accountRepository;

        [SetUp]
        public void Setup()
        {
            _accountRepository = new AccountRepositoryDirectAccess(_substrateRepository);
        }

        [Test]
        [TestCase("5He5uUCWMLXvfJmSWTcD2ZHDerBU4VH91z92SekRcctuGifV", "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        [TestCase("", "124X3VPduasSodAjS6MPd5nEqM8SUdKN5taMUUPtkWqF1fVf")]
        public async Task ValidAccount_GetDetails_ShouldWorkAsync(string ss58, string polkadotAdress)
        {
            if(!string.IsNullOrEmpty(ss58))
            {
                Assert.That(Utils.GetPublicKeyFrom(ss58), Is.EqualTo(Utils.GetPublicKeyFrom(polkadotAdress)));
            }

            var res = await _accountRepository.GetAccountDetailAsync(polkadotAdress, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
