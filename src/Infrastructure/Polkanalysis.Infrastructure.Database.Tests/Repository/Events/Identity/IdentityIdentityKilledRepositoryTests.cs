using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Identity;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Identity
{
    internal class IdentityIdentityKilledRepositoryTests : EventsDatabaseTests
    {
        private IdentityIdentityKilledRepository _identityIdentityKilledRepository;

        [SetUp]
        public void Setup()
        {
            _identityIdentityKilledRepository = new IdentityIdentityKilledRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<IdentityIdentityKilledRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventIdentityIdentityKilled.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString(), 10));
            _substrateDbContext.EventIdentityIdentityKilled.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "", "", Bob.ToString(), 10));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_identityIdentityKilledRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, FiveDots, 5)]
        public async Task BuildModel_WhenValidIdentityKilled_ShouldBuildModelSuccessfullyAsync(string accountAddress, double amount, double expected)
        {
            var enumContribution = new Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent();
            enumContribution.Create(
                Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentityKilled,
                new BaseTuple<SubstrateAccount, U128>(
                    new SubstrateAccount(accountAddress),
                    new U128(new BigInteger(amount))));

            var model = await _identityIdentityKilledRepository.BuildModelAsync(
                BuildEventModel("Identity", "Killed"),
                enumContribution,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Identity"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Killed"));
            Assert.That(model.AccountAddress, Is.EqualTo(MockAddress));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _identityIdentityKilledRepository.SearchAsync(new()
            {
                Amount = NumberCriteria<double>.GreaterThan(10)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(0));
        }
    }
}
