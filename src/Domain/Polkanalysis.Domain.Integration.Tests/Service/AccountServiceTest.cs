using NUnit.Framework;
using Substrate.NetApi;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using NSubstitute;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Microsoft.Extensions.Caching.Hybrid;

namespace Polkanalysis.Domain.Integration.Tests.Service
{
    [CancelAfter(RepositoryMaxTimeout)]
    public class AccountServiceTest : PolkadotIntegrationTest
    {
        private IAccountService _accountRepository;

        [SetUp]
        public void Setup()
        {
            _accountRepository = new AccountService(_substrateService, _substrateDbContext, Substitute.For<ILogger<AccountService>>(), Substitute.For<HybridCache>());
        }

        [Test]
        [TestCase("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        public async Task ValidAccount_GetDetails_ShouldWorkAsync(string polkadotAdress)
        {
            var res = await _accountRepository.GetAccountDetailAsync(polkadotAdress, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase("0x78822d5254a3a6d3b9583c2cf8cdb94866fef78f65e0dd541880736f1354db55", "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        [TestCase("0x78822d5254a3a6d3b9583c2cf8cdb94866fef78f65e0dd541880736f1354db55", "16ZL8yLyXv3V3L3z9ofR1ovFLziyXaN1DPq4yffMAZ9czzBD")]
        [TestCase("0x78822d5254a3a6d3b9583c2cf8cdb94866fef78f65e0dd541880736f1354db55", "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")]
        [TestCase("0x78822d5254a3a6d3b9583c2cf8cdb94866fef78f65e0dd541880736f1354db55", "124X3VPduasSodAjS6MPd5nEqM8SUdKN5taMUUPtkWqF1fVf")]
        [TestCase("0x78822d5254a3a6d3b9583c2cf8cdb94866fef78f65e0dd541880736f1354db55", "16AjunUasoBZKWkDnHvNEALGUgGuzC92j7LJoLu9qBSUJB2e")]
        public async Task ValidAccount_At_GetDetails_ShouldWorkAsync(string blockHash, string polkadotAdress)
        {
            var res = await _accountRepository.At(blockHash).GetAccountDetailAsync(polkadotAdress, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [CancelAfter(30_000)]
        public async Task GetAllAccount_ShouldWorkAsync()
        {
            var res = await _accountRepository.GetAccountsAsync(CancellationToken.None, Contracts.Common.Pagination.Default);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count(), Is.GreaterThan(0));
        }

        [Test]
        [TestCase("11VR4pF6c7kfBhfmuwwjWY3FodeYBKWx7ix2rsRCU2q6hqJ")]
        public async Task GetIdentityFromAccount_ShouldSuceedAsync(string accountAddress)
        {
            var res = await _accountRepository.GetAccountIdentityAsync(accountAddress, CancellationToken.None);
            
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Name, Is.Not.EqualTo(res.Address));
        }

        [Test]
        [TestCase("11VR4pF6c7kfBhfmuwwjWY3FodeYBKWx7ix2rsRCU2q6hqJ")]
        public async Task GetBalancesAsync_ShouldSucceedAsync(string accountAddress)
        {
            var res1 = await _accountRepository.GetBalancesAsync(accountAddress, CancellationToken.None);
            var res2 = await _accountRepository.GetBalancesAsync(new SubstrateAccount(accountAddress), CancellationToken.None);

            Assert.That(res1, Is.Not.Null);
            Assert.That(res2, Is.Not.Null);
            Assert.That(res1.Total.Native, Is.GreaterThan(0));
            Assert.That(res1.Total.Native, Is.EqualTo(res2.Total.Native));
        }

        [Test]
        [TestCase("0x8a6f3de406319c13db54b4988fd172e0ae832ba2fe66c9d87578db4e1c5a929a", "14GWWeZzMYkR7bwyeBvq7c44nJr4ncEodM4fAJX89ZSAHLw3", "BINANCE_STAKE_13")]
        [TestCase("0x8a6f3de406319c13db54b4988fd172e0ae832ba2fe66c9d87578db4e1c5a929a", "158B1DyQ2Ep5b5G4akA2mjUJeDwgZZ4Sh1ePnkGgcWrgtPMs", "senseinode.com")]
        public async Task GetAccountIdentity_DelegateToPeopleChain_ShouldSucceedAsync(string blockHash, string accountAddress, string expected)
        {
            var res = await _accountRepository.At(blockHash).GetAccountIdentityAsync(accountAddress, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Name, Is.EqualTo(expected));
        }
    }
}
