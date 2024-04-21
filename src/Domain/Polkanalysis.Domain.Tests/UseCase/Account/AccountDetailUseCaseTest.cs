using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Polkanalysis.Domain.UseCase;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Tests.UseCase.Account
{
    public class AccountDetailUseCaseTest : UseCaseTest<AccountDetailHandler, AccountDto, AccountDetailQuery>
    {
        private IAccountService _accountService;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<AccountDetailHandler>>();
            _accountService = Substitute.For<IAccountService>();

            _useCase = new AccountDetailHandler(_accountService, _logger);
            //base.Setup();
        }
    }
}
