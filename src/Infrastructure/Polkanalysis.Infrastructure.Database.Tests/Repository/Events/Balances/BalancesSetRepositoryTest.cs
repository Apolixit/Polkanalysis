using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Hub;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
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
        private BalancesBalanceSetRepository _balancesSetRepository;

        [SetUp]
        public void Setup()
        {
            _balancesSetRepository = new BalancesBalanceSetRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<BalancesBalanceSetRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventBalancesBalanceSet.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "Auctions", "Started", Alice.ToString(), 10, 20));
            _substrateDbContext.EventBalancesBalanceSet.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "Auctions", "Started", Alice.ToString(), 20, 40));
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

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _balancesSetRepository.SearchAsync(new()
            {
                RootAccount = Alice.ToString(),
                Amount1 = NumberCriteria<double>.GreaterOrEqualThan(10),
                Amount2 = NumberCriteria<double>.LowerStrict(30)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
