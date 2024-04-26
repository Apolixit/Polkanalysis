using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Repository.Events.Identity;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Identity
{
    internal class IdentityIdentityClearedRepositoryTests : EventsDatabaseTests
    {
        private IdentityIdentityClearedRepository _identityIdentityClearedRepository;

        [SetUp]
        public void Setup()
        {
            _identityIdentityClearedRepository = new IdentityIdentityClearedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IBlockchainMapping>(),
                Substitute.For<ILogger<IdentityIdentityClearedRepository>>());
        }

        [Test]
        [TestCase(MockAddress, FiveDots, 5)]
        public async Task BuildModel_WhenValidIdentityCleared_ShouldBuildModelSuccessfullyAsync(string accountAddress, double amount, double expected)
        {
            var enumContribution = new Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent();
            enumContribution.Create(
                Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentityCleared,
                new BaseTuple<SubstrateAccount, U128>(
                    new SubstrateAccount(accountAddress),
                    new U128(new System.Numerics.BigInteger(amount))));

            var model = await _identityIdentityClearedRepository.BuildModelAsync(
                BuildEventModel("Identity", "Cleared"),
                enumContribution,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Identity"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Cleared"));
            Assert.That(model.Account, Is.EqualTo(MockAddress));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }
    }
}
