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
    public class BalancesReservedRepositoryTest : EventsDatabaseTests
    {
        private BalancesReservedRepository _balancesReservedRepository;

        [SetUp]
        public void Setup()
        {
            _balancesReservedRepository = new BalancesReservedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<BalancesReservedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventBalancesReserved.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "Auctions", "Started", Alice.ToString(), 10));
            _substrateDbContext.EventBalancesReserved.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "Auctions", "Started", Alice.ToString(), 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_balancesReservedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, TenDots, 10)]
        public async Task BuildModel_WhenValidReserved_ShouldBuildModelSuccessfullyAsync(string account, double amount, double expected)
        {
            var enumReserved = new Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent();
            enumReserved.Create(
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Reserved,
                    new BaseTuple<SubstrateAccount, U128>(
                        new SubstrateAccount(account),
                        new U128(new BigInteger(amount))

            ));

            var model = await _balancesReservedRepository.BuildModelAsync(
                BuildEventModel("Balances", "Reserved"),
                enumReserved,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Balances"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Reserved"));
            Assert.That(model.AccountAddress, Is.EqualTo(account));
            Assert.That(model.ReservedAmount, Is.EqualTo(expected));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _balancesReservedRepository.SearchAsync(new()
            {
                AccountAddress = Alice.ToString(),
                ReservedAmount = NumberCriteria<double>.GreaterThan(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
