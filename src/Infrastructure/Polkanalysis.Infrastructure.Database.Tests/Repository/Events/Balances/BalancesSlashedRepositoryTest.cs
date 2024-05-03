using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
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
                Substitute.For<IBlockchainMapping>(),
                Substitute.For<ILogger<BalancesSlashedRepository>>());
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
            Assert.That(model.Account, Is.EqualTo(account));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }
    }
}
