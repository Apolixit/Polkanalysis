using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Hub;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Crowdloan
{
    public class CrowloanContributedRepositoryTests : EventsDatabaseTests
    {
        private CrowdloanContributedRepository _crowloanContributedRepository;

        [SetUp]
        public void Setup()
        {
            _crowloanContributedRepository = new CrowdloanContributedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<CrowdloanContributedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventCrowdloanContributed.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString(), 1, 10));
            _substrateDbContext.EventCrowdloanContributed.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString(), 2, 20));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_crowloanContributedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, 10u, 52_500_000_000, 5.25)]
        public async Task BuildModel_WhenValidCrowdloanContribution_ShouldBuildModelSuccessfullyAsync(string accountAddress, uint crowdloanId, double amount, double expected)
        {
            var enumContribution = new Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent();
            enumContribution.Create(
                Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.Event.Contributed,
                new BaseTuple<SubstrateAccount, Id, U128>(
                    new SubstrateAccount(accountAddress),
                    new Id((uint)crowdloanId),
                    new U128(new System.Numerics.BigInteger(amount))));

            var model = await _crowloanContributedRepository.BuildModelAsync(
                BuildEventModel("Crowdloan", "Contribution"),
                enumContribution, 
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Crowdloan"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Contribution"));
            Assert.That(model.AccountAddess, Is.EqualTo(MockAddress));
            Assert.That(model.CrowdloanId, Is.EqualTo(crowdloanId));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _crowloanContributedRepository.SearchAsync(new()
            {
                AccountAddess = Alice.ToString(),
                CrowdloanId = NumberCriteria<uint>.Equal(1)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
