using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Balances
{
    internal class BalancesTransferRepositoryTests : EventsDatabaseTests
    {
        private BalancesTransferRepository _balancesTransferRepository;

        [SetUp]
        public void Setup()
        {
            _balancesTransferRepository = new BalancesTransferRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IBlockchainMapping>(),
                Substitute.For<ILogger<BalancesTransferRepository>>());
        }

        [Test]
        [TestCase(MockAddress, MockAddress2, TenDots, 10)]
        public async Task BuildModel_WhenValidTransfert_ShouldBuildModelSuccessfullyAsync(string from, string to, double amount, double expected)
        {
            var enumTransfert = new Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent();
            enumTransfert.Create(
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Transfer,
                    new BaseTuple<SubstrateAccount, SubstrateAccount, U128>(
                        new SubstrateAccount(from), 
                        new SubstrateAccount(to), 
                        new U128(new System.Numerics.BigInteger(amount))
                    
            ));

            var model = await _balancesTransferRepository.BuildModelAsync(
                BuildEventModel("Balances", "Transfert"),
                enumTransfert,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Balances"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Transfert"));
            Assert.That(model.From, Is.EqualTo(from));
            Assert.That(model.To, Is.EqualTo(to));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }
    }
}
