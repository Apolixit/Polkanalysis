using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
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

        [Test, Ignore("Debug")]
        public async Task GetAccountsNull_ShouldReturnEmptyAsync()
        {
            //_substrateRepository.Storage.System.AccountsQueryAsync(Arg.Any<CancellationToken>())
            //    .Returns(new QueryStorage<SubstrateAccount, AccountInfo>(new Func<QueryStorageFunction, QueryFilterFunction, CancellationToken, Task<List<(SubstrateAccount, AccountInfo)>>>);
            //        //Arg.Any<Func<QueryStorageFunction, QueryFilterFunction, CancellationToken, Task<List<(SubstrateAccount, AccountInfo)>>>>(),
            //        //Arg.Any<QueryStorageFunction>()));

            //var res = await _accountService.GetAccountsAsync(CancellationToken.None);
            //Assert.That(res.Count(), Is.EqualTo(0));
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

        [Test]
        public void GetAccountsIdentityWithInvalidAddress_ShouldThrowException()
        {
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountIdentityAsync((string)null!, CancellationToken.None));
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountIdentityAsync(string.Empty, CancellationToken.None));
                Assert.ThrowsAsync<AddressException>(async () => await _accountService.GetAccountIdentityAsync("InvalidAddressHash", CancellationToken.None));
            });
        }
    }
}
