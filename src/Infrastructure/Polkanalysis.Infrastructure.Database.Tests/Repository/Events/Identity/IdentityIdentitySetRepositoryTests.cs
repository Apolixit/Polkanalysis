﻿using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
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
    internal class IdentityIdentitySetRepositoryTests : EventsDatabaseTests
    {
        private IdentityIdentitySetRepository _identityIdentitySetRepository;

        [SetUp]
        public void Setup()
        {
            _identityIdentitySetRepository = new IdentityIdentitySetRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<IdentityIdentitySetRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventIdentityIdentitySet.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString()));
            _substrateDbContext.EventIdentityIdentitySet.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "", "", Bob.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_identityIdentitySetRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress)]
        public async Task BuildModel_WhenValidIdentitySet_ShouldBuildModelSuccessfullyAsync(string accountAddress)
        {
            var enumContribution = new Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent();
            enumContribution.Create(
                Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentitySet,
                new SubstrateAccount(accountAddress));

            var model = await _identityIdentitySetRepository.BuildModelAsync(
                BuildEventModel("Identity", "Set"),
                enumContribution,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Identity"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Set"));
            Assert.That(model.AccountAddress, Is.EqualTo(MockAddress));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _identityIdentitySetRepository.SearchAsync(new()
            {
                AccountAddress = Alice.ToString(),
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
