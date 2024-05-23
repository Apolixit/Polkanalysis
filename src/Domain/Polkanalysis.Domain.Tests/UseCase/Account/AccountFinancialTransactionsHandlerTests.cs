using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Substrate.NetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Account
{
    public class AccountFinancialTransactionsHandlerTests : UseCaseTest<AccountFinancialTransactionsHandler, AccountFinancialTransactionsDto, AccountFinancialTransactionsQuery>
    {
        protected IFinancialService _financialService;
        protected IAccountService _accountService;

        [SetUp]
        public void Setup()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;
            _substrateDbContext = new SubstrateDbContext(contextOption);
            PopulateDatabase();

            _financialService = new FinancialService(Substitute.For<ISubstrateService>(), _substrateDbContext, Substitute.For<ILogger<FinancialService>>());
            _accountService = Substitute.For<IAccountService>();

            _accountService.GetAccountAddressAsync(Alice.ToString(), CancellationToken.None)
                .Returns(new UserAddressDto() { 
                    Address = Alice.ToString(), 
                    Name = "Alice", 
                    PublicKey = Utils.Bytes2HexString(Alice.Bytes) });

            _logger = Substitute.For<ILogger<AccountFinancialTransactionsHandler>>();

            _useCase = new AccountFinancialTransactionsHandler( _logger, _financialService, _accountService, Substitute.For<IDistributedCache>());
            //base.Setup();
        }

        private void PopulateDatabase()
        {
            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 10, new DateTime(2024, 1, 1), 12, "Balances", "Transfer", Alice.ToString(), Bob.ToString(), 10));

            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 100, new DateTime(2024, 1, 1), 12, "Balances", "Transfer", Alice.ToString(), Bob.ToString(), 15));

            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 1_000, new DateTime(2024, 1, 2), 12, "Balances", "Transfer", Alice.ToString(), Bob.ToString(), 25));

            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 1_004, new DateTime(2024, 1, 2), 12, "Balances", "Transfer", RandomAccount.ToString(), Alice.ToString(), 20));

            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 10_000, new DateTime(2024, month: 2, 2), 12, "Balances", "Transfer", Bob.ToString(), Alice.ToString(), 30));

            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 10_001, new DateTime(2024, month: 2, 2), 12, "Balances", "Transfer", Alice.ToString(), RandomAccount.ToString(), 5));

            _substrateDbContext.SaveChanges();
        }

        [Test]
        public async Task AccountFinancialTransactions_WithValidUseCase_ShouldSucceedAsync()
        {
            var from = new DateTime(2024, 01, 01);
            var to = new DateTime(2024, 02, 01);
            var result = await _useCase!.HandleInnerAsync(
                new AccountFinancialTransactionsQuery(Alice.ToString(), from, to), CancellationToken.None);

            Assert.That(result.IsError, Is.False);
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.TotalAmountSent.Native, Is.EqualTo(50));
            Assert.That(result.Value.TotalAmountReceived.Native, Is.EqualTo(20));
            Assert.That(result.Value.Address.Name, Is.EqualTo("Alice"));
            Assert.That(result.Value.From, Is.EqualTo(from));
            Assert.That(result.Value.To, Is.EqualTo(to));
        }

        [Test]
        public void AccountFinancialTransactionValidator_ShouldSucceed()
        {
            _substrateService.IsValidAccountAddress(Arg.Is<string>(x => x == "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS")).Returns(true);
            _substrateService.IsValidAccountAddress(Arg.Is<string>(x => x == "toto")).Returns(false);

            var validationResultSuccess = new AccountFinancialTransactionsValidator(_substrateService)
                .Validate(new AccountFinancialTransactionsQuery("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS", null, null));
            var validationResultFail = new AccountFinancialTransactionsValidator(_substrateService)
                .Validate(new AccountFinancialTransactionsQuery("toto", null, null));

            Assert.Multiple(() =>
            {
                Assert.That(validationResultSuccess.IsValid, Is.EqualTo(true));
                Assert.That(validationResultFail.IsValid, Is.EqualTo(false));
            });
        }
    }
}
