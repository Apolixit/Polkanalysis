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
            Assert.That(model.Account, Is.EqualTo(account));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }
    }
}
