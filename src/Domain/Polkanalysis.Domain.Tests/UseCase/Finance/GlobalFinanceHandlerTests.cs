using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.FInancial;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Account;
using Polkanalysis.Domain.UseCase.Statistics.Finance;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Finance
{
    public class GlobalFinanceHandlerTests : UseCaseTest<GlobalFinanceHandler, GlobalFinanceDto, GlobalFinanceQuery>
    {
        protected ISubstrateService _substrateService;
        protected IFinancialService _financialService;
        protected IExplorerService _explorerService;

        [SetUp]
        public void Setup()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;
            _substrateDbContext = new SubstrateDbContext(contextOption);
            _logger = Substitute.For<ILogger<GlobalFinanceHandler>>();

            PopulateDatabase();

            ulong nbTickIn60Year = 60 * 365 * 60 * 60 * 24 * (ulong)Math.Pow(10, 3);
            _substrateService = Substitute.For<ISubstrateService>();
            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), CancellationToken.None).Returns(
                new Hash("0x00"));
            _substrateService.At(Arg.Any<Hash>()).Storage.Timestamp.NowAsync(CancellationToken.None).Returns(new U64(nbTickIn60Year));

            _financialService = new FinancialService(_substrateService,
                                                     _substrateDbContext,
                                                     Substitute.For<ILogger<FinancialService>>());

            _explorerService = new ExplorerService(_substrateService,
                                                   Substitute.For<ISubstrateDecoding>(),
                                                   Substitute.For<IModelBuilder>(),
                                                   Substitute.For<IAccountService>(),
                                                   Substitute.For<ILogger<ExplorerService>>());

            

            _useCase = new GlobalFinanceHandler(_financialService, _logger, _explorerService);
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
                blockchainName: "Polkadot", 1_004, new DateTime(2024, 1, 2), 12, "Balances", "Transfer", RandomAccount.ToString(), Alice.ToString(), 20));

            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 10_000, new DateTime(2024, month: 2, 2), 12, "Balances", "Transfer", Bob.ToString(), Alice.ToString(), 30));

            _substrateDbContext.EventBalancesTransfer.Add(new BalancesTransferModel(
                "Polkadot", 10_001, new DateTime(2024, month: 2, 2), 12, "Balances", "Transfer", Alice.ToString(), RandomAccount.ToString(), 5));

            _substrateDbContext.SaveChanges();
        }

        [Test]
        public async Task BlockDetailUseCaseReturnNullDto_ShouldFailedAsync()
        {
            var from = new DateTime(2024, 01, 01);
            var to = new DateTime(2024, 02, 01);
            var result = await _useCase.Handle(
                new GlobalFinanceQuery(from, to), CancellationToken.None);

            Assert.That(result.IsError, Is.False);
            Assert.That(result.IsSuccess, Is.True);

            Assert.That(result.Value.From, Is.EqualTo(from));
            Assert.That(result.Value.To, Is.EqualTo(to));

            Assert.That(result.Value.Volume.Native, Is.EqualTo(70));

            Assert.That(result.Value.VolumePerDay.Count, Is.EqualTo(2));
            Assert.That(result.Value.VolumePerDay[0].From, Is.EqualTo(new DateTime(2024, 1, 1)));
            Assert.That(result.Value.VolumePerDay[0].To, Is.EqualTo(new DateTime(2024, 1, 1)));
            Assert.That(result.Value.VolumePerDay[0].Amount, Is.EqualTo(25));

            Assert.That(result.Value.VolumePerDay[1].From, Is.EqualTo(new DateTime(2024, 1, 2)));
            Assert.That(result.Value.VolumePerDay[1].To, Is.EqualTo(new DateTime(2024, 1, 2)));
            Assert.That(result.Value.VolumePerDay[1].Amount, Is.EqualTo(45));


            Assert.That(result.Value.AverageTransactionAmountPerDay.Count, Is.EqualTo(2));
            Assert.That(result.Value.AverageTransactionAmountPerDay[0].From, Is.EqualTo(new DateTime(2024, 1, 1)));
            Assert.That(result.Value.AverageTransactionAmountPerDay[0].To, Is.EqualTo(new DateTime(2024, 1, 1)));
            Assert.That(result.Value.AverageTransactionAmountPerDay[0].Amount, Is.EqualTo(12.5));

            Assert.That(result.Value.AverageTransactionAmountPerDay[1].From, Is.EqualTo(new DateTime(2024, 1, 2)));
            Assert.That(result.Value.AverageTransactionAmountPerDay[1].To, Is.EqualTo(new DateTime(2024, 1, 2)));
            Assert.That(result.Value.AverageTransactionAmountPerDay[1].Amount, Is.EqualTo(22.5));
        }
    }
}
