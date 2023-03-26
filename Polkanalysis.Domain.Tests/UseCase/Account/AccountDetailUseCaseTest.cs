using Substats.Domain.Contracts.Secondary;
using Substats.Domain.UseCase.Explorer.Block;
using Substats.Domain.UseCase;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.UseCase.Account;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.Contracts.Dto.User;

namespace Substats.Domain.Tests.UseCase.Account
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
