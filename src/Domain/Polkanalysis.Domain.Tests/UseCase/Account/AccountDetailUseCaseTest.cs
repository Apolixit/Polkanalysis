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
        private IAccountService _accountRepository;

        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<AccountDetailHandler>>();
            _accountRepository = Substitute.For<IAccountService>();

            _useCase = new AccountDetailHandler(_accountRepository, _logger);
            base.Setup();
        }
    }
}
