﻿using NUnit.Framework;
using Substrate.NetApi;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using NSubstitute;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Domain.Integration.Tests.Service
{
    [Timeout(RepositoryMaxTimeout)]
    public class AccountServiceTest : PolkadotIntegrationTest
    {
        private IAccountService _accountRepository;

        [SetUp]
        public void Setup()
        {
            _accountRepository = new AccountService(_substrateService, _substrateDbContext, Substitute.For<ILogger<AccountService>>());
        }

        [Test]
        [TestCase("", "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        [TestCase("", "16ZL8yLyXv3V3L3z9ofR1ovFLziyXaN1DPq4yffMAZ9czzBD")]
        [TestCase("5He5uUCWMLXvfJmSWTcD2ZHDerBU4VH91z92SekRcctuGifV", "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        [TestCase("", "124X3VPduasSodAjS6MPd5nEqM8SUdKN5taMUUPtkWqF1fVf")]
        [TestCase("", "16AjunUasoBZKWkDnHvNEALGUgGuzC92j7LJoLu9qBSUJB2e")]
        public async Task ValidAccount_GetDetails_ShouldWorkAsync(string ss58, string polkadotAdress)
        {
            if (!string.IsNullOrEmpty(ss58))
            {
                Assert.That(Utils.GetPublicKeyFrom(ss58), Is.EqualTo(Utils.GetPublicKeyFrom(polkadotAdress)));
            }

            var res = await _accountRepository.GetAccountDetailAsync(polkadotAdress, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [Timeout(30_000)]
        public async Task GetAllAccount_ShouldWorkAsync()
        {
            var res = await _accountRepository.GetAccountsAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count(), Is.GreaterThan(0));
        }
    }
}
