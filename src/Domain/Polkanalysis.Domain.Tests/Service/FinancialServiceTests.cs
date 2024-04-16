using Microsoft.EntityFrameworkCore;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Service
{
    public class FinancialServiceTests : DomainTestAbstract
    {
        private IFinancialService _financialService;

        public void Sart()
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
        }

        [Test]
        [TestCase(null, null, 4, 3, 1)]
        [TestCase("2024-1-1", "2024-1-31", 3, 3, 0)]
        public async Task GetAccountTransactionsAsync_ForBobTransaction_ShouldSucceedAsync(DateTime? from, DateTime? to, int nbTotalTransaction, int nbReceivedTransaction, int nbSendTransaction)
        {
            // Get all Bob transactions
            var result = (await _financialService.GetAccountTransactionsAsync(new Contracts.Core.SubstrateAccount(Bob.ToString()), from, to, CancellationToken.None)).ToList();

            Assert.That(result.Count(), Is.EqualTo(nbTotalTransaction));

            // Bob received money 3 times
            Assert.That(result.Where(x => x.GetTypeTransaction(Bob.ToString()) == Contracts.Dto.Financial.TransactionDto.TypeTransactionDto.Received).Count(), Is.EqualTo(nbReceivedTransaction));

            // Bob sent money 1 time
            Assert.That(result.Where(x => x.GetTypeTransaction(Bob.ToString()) == Contracts.Dto.Financial.TransactionDto.TypeTransactionDto.Send).Count(), Is.EqualTo(nbSendTransaction));
        }

        [Test]
        [TestCase(null, null, 6)]
        [TestCase("2024-1-1", "2024-1-1", 2)]
        [TestCase("2025-1-1", "2026-1-1", 0)]
        public async Task GetTransactionsAsync_ShouldSucceedAsync(DateTime? from, DateTime? to, int nbTotalTransaction)
        {
            // Get all Bob transactions
            var result = (await _financialService.GetTransactionsAsync(from, to, CancellationToken.None)).ToList();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(nbTotalTransaction));
        }
    }
}
