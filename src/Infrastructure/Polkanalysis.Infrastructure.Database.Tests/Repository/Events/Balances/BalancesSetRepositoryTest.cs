using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Balances
{
    public class BalancesSetRepositoryTest : EventsDatabaseTests
    {
        private BalancesSetRepository _balancesSetRepository;

        [SetUp]
        public void Setup()
        {
            _balancesSetRepository = new BalancesSetRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<BalancesSetRepository>>());
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_balancesSetRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, TenDots, FiveDots, 10, 5)]
        public async Task BuildModel_WhenValidBalancesSet_ShouldBuildModelSuccessfullyAsync(string account, double amount1, double amount2, double expected1, double expected2)
        {
            var enumBalanceSet = new Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent();
            enumBalanceSet.Create(
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.BalanceSet,
                    new BaseTuple<SubstrateAccount, U128, U128>(
                        new SubstrateAccount(account),
                        new U128(new BigInteger(amount1)),
                        new U128(new BigInteger(amount2))
                        )
            );

            var model = await _balancesSetRepository.BuildModelAsync(
                BuildEventModel("Balances", "BalanceSet"),
                enumBalanceSet,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Balances"));
            Assert.That(model.ModuleEvent, Is.EqualTo("BalanceSet"));
            Assert.That(model.RootAccount, Is.EqualTo(account));
            Assert.That(model.Amount1, Is.EqualTo(expected1));
            Assert.That(model.Amount2, Is.EqualTo(expected2));
        }
    }
}
