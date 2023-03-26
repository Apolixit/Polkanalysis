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

namespace Polkanalysis.Domain.Tests.UseCase.Account
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
