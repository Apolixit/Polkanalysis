using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
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
    public class BalancesEndowedRepositoryTest : EventsDatabaseTests
    {
        private BalancesEndowedRepository _balancesEndowedRepository;

        [SetUp]
        public void Setup()
        {
            _balancesEndowedRepository = new BalancesEndowedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<BalancesEndowedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventBalancesEndowed.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "Auctions", "Started", Alice.ToString(), 10));
            _substrateDbContext.EventBalancesEndowed.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "Auctions", "Started", Alice.ToString(), 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_balancesEndowedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, TenDots, 10)]
        public async Task BuildModel_WhenValidEndowed_ShouldBuildModelSuccessfullyAsync(string account, double amount, double expected)
        {
            var enumEndowed = new Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent();
            enumEndowed.Create(
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Endowed,
                    new BaseTuple<SubstrateAccount, U128>(
                        new SubstrateAccount(account),
                        new U128(new BigInteger(amount))

            ));

            var model = await _balancesEndowedRepository.BuildModelAsync(
                BuildEventModel("Balances", "Endowed"),
                enumEndowed,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Balances"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Endowed"));
            Assert.That(model.AccountAddress, Is.EqualTo(account));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _balancesEndowedRepository.SearchAsync(new()
            {
                AccountAddress = Alice.ToString(),
                Amount = NumberCriteria<double>.GreaterThan(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
