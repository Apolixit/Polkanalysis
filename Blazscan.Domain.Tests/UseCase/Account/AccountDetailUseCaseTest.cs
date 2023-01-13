using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Domain.UseCase.Explorer.Block;
using Blazscan.Domain.UseCase;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazscan.Domain.UseCase.Account;
using Blazscan.Domain.Contracts.Primary;
using Blazscan.Domain.Contracts;

namespace Blazscan.Domain.Tests.UseCase.Account
{
    public class AccountDetailUseCaseTest : UseCaseTest<AccountDetailUseCase, AccountDto, AccountCommand>
    {
        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<AccountDetailUseCase>>();
            _useCase = new AccountDetailUseCase(_logger);
            base.Setup();
        }
    }
}
