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
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Configuration.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;

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
            _useCase = new AccountDetailHandler(_accountService, _logger, Substitute.For<HybridCache>());
        }

        [Test]
        public void AccountDetailValidator_ShouldSucceed()
        {
            _substrateService.IsValidAccountAddress(Arg.Is<string>(x => x == "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")).Returns(true);
            _substrateService.IsValidAccountAddress(Arg.Is<string>(x => x == "toto")).Returns(false);

            var validationResultSuccess = new AccountDetailValidator(_substrateService)
                .Validate(new AccountDetailQuery() { AccountAddress = "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS" });
            var validationResultFail = new AccountDetailValidator(_substrateService)
                .Validate(new AccountDetailQuery() { AccountAddress = "toto" });

            Assert.Multiple(() =>
            {
                Assert.That(validationResultSuccess.IsValid, Is.EqualTo(true));
                Assert.That(validationResultFail.IsValid, Is.EqualTo(false));
            });
        }
    }
}
