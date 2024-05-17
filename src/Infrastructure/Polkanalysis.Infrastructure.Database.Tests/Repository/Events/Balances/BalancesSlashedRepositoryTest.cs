using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
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
    public class BalancesSlashedRepositoryTest : EventsDatabaseTests
    {
        private BalancesSlashedRepository _balancesSlashedRepository;

        [SetUp]
        public void Setup()
        {
            _balancesSlashedRepository = new BalancesSlashedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<BalancesSlashedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventBalancesSlashed.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString(), 10));
            _substrateDbContext.EventBalancesSlashed.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString(), 12));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_balancesSlashedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, TenDots, 10)]
        public async Task BuildModel_WhenValiEndowed_ShouldBuildModelSuccessfullyAsync(string account, double amount, double expected)
        {
            var enumSlashed = new Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent();
            enumSlashed.Create(
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Slashed,
                    new BaseTuple<SubstrateAccount, U128>(
                        new SubstrateAccount(account),
                        new U128(new BigInteger(amount))

            ));

            var model = await _balancesSlashedRepository.BuildModelAsync(
                BuildEventModel("Balances", "Slashed"),
                enumSlashed,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Balances"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Slashed"));
            Assert.That(model.AccountAddess, Is.EqualTo(account));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _balancesSlashedRepository.SearchAsync(new()
            {
                AccountAddess = Alice.ToString(),
                Amount = NumberCriteria<double>.Between(5, 15),
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(2));
        }
    }
}
