using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Domain.UseCase.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Account
{
    public class AccountListHandlerTests : UseCaseTest<AccountListHandler, PagedResponseDto<AccountLightDto>, AccountsQuery>
    {
        private IAccountService _accountRepository;

        [SetUp]
        public void Setup()
        {
            _accountRepository = Substitute.For<IAccountService>();
            _logger = Substitute.For<ILogger<AccountListHandler>>();
            _useCase = new AccountListHandler(_accountRepository, _logger, Substitute.For<IDistributedCache>());
        }

        [Test]
        public async Task AccountListHandler_WithValidAccounts_ShouldReturnPagedResponseDtoAsync()
        {
            var accounts = new List<AccountLightDto>()
            {
                new AccountLightDto()
                {
                    Address = new UserAddressDto() { Name = "Alice", Address = Alice.ToString() },
                    Balances = new Contracts.Dto.Balances.BalancesDto()
                    {
                    }
                },
                new AccountLightDto()
                {
                    Address = new UserAddressDto() { Name = "Bob", Address = Bob.ToString() },
                    Balances = new Contracts.Dto.Balances.BalancesDto()
                    {
                    }
                },
                new AccountLightDto()
                {
                    Address = new UserAddressDto() { Name = "RandomAccount", Address = RandomAccount.ToString() },
                    Balances = new Contracts.Dto.Balances.BalancesDto()
                    {
                    }
                }
            };

            _accountRepository.GetAccountsAsync(CancellationToken.None,Arg.Any<Pagination>()).Returns(accounts);

            var result = await _useCase!.HandleInnerAsync(new AccountsQuery(2, 1) { }, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.Value.Data.Count(), Is.EqualTo(2));
            Assert.That(result.Value.TotalPages, Is.EqualTo(2));
            Assert.That(result.Value.TotalRecords, Is.EqualTo(3));
        }   
    }
}
