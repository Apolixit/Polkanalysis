using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
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
    public class BalancesUnreservedRepositoryTest : EventsDatabaseTests
    {
        private BalancesUnreservedRepository _balancesUnreservedRepository;

        [SetUp]
        public void Setup()
        {
            _balancesUnreservedRepository = new BalancesUnreservedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<BalancesUnreservedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventBalancesUnreserved.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString(), 10));
            _substrateDbContext.EventBalancesUnreserved.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString(), 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_balancesUnreservedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, TenDots, 10)]
        public async Task BuildModel_WhenValidUnreserved_ShouldBuildModelSuccessfullyAsync(string account, double amount, double expected)
        {
            var enumUnreserved = new Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent();
            enumUnreserved.Create(
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Unreserved,
                    new BaseTuple<SubstrateAccount, U128>(
                        new SubstrateAccount(account),
                        new U128(new BigInteger(amount))

            ));

            var model = await _balancesUnreservedRepository.BuildModelAsync(
                BuildEventModel("Balances", "Unreserved"),
                enumUnreserved,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Balances"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Unreserved"));
            Assert.That(model.AccountAddess, Is.EqualTo(account));
            Assert.That(model.UnreservedAmount, Is.EqualTo(expected));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _balancesUnreservedRepository.SearchAsync(new()
            {
                AccountAddess = Alice.ToString(),
                UnreservedAmount = NumberCriteria<double>.Equal(20)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
