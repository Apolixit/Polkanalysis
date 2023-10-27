using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;

namespace Polkanalysis.Domain.Tests.Service
{
    public class AccountServiceTest
    {
        private IAccountService _accountService;
        private ISubstrateService _substrateRepository;

        [SetUp]
        public void Setup()
        {
            _substrateRepository = Substitute.For<ISubstrateService>();
            _accountService = new AccountService(_substrateRepository);
        }

        [Test]
        public async Task GetAccountsWithValidResponse_ShouldSucceedAsync()
        {
            var res = await _accountService.GetAccountsAsync(CancellationToken.None);
            Assert.Fail();
        }

        [Test]
        public async Task GetAccountsNull_ShouldReturnEmptyAsync()
        {
            _substrateRepository.Storage.System.AccountsQuery().Returns(new Infrastructure.Blockchain.Contracts.Common.QueryStorage<SubstrateAccount, AccountInfo>(Arg.Any<Func<string, string, CancellationToken, int?, int?, Task<List<(SubstrateAccount, AccountInfo)>>>>(), "module", "test"));
            //accountsQuery.Take(Arg.Any<int>()).ExecuteAsync(Arg.Any<CancellationToken>()).ReturnsNull();

            var res = await _accountService.GetAccountsAsync(CancellationToken.None);
            Assert.That(res.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task GetAccountsDetailsWithValidResponse_ShouldSucceedAsync()
        {
            var res = await _accountService.GetAccountDetailAsync("", CancellationToken.None);
            Assert.Fail();
        }

        [Test]
        public async Task GetAccountsIdentityWithValidResponse_ShouldSucceedAsync()
        {
            var res = await _accountService.GetAccountIdentityAsync("", CancellationToken.None);
            Assert.Fail();
        }

        [Test]
        public void GetAccountsDetailsWithInvalidAddress_ShouldThrowException()
        {
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountDetailAsync(null!, CancellationToken.None));
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountDetailAsync(string.Empty, CancellationToken.None));
                Assert.ThrowsAsync<AddressException>(async () => await _accountService.GetAccountDetailAsync("InvalidAddressHash", CancellationToken.None));
            });
        }
    }
}
