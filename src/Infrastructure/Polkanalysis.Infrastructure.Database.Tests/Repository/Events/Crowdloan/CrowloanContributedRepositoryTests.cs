using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
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
        private CrowloanContributedRepository _crowloanContributedRepository;

        [SetUp]
        public void Setup()
        {
            _crowloanContributedRepository = new CrowloanContributedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<CrowloanContributedRepository>>());
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_crowloanContributedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress, 10, 52_500_000_000, 5.25)]
        public async Task BuildModel_WhenValidCrowdloanContribution_ShouldBuildModelSuccessfullyAsync(string accountAddress, int crowdloanId, double amount, double expected)
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
            Assert.That(model.Account, Is.EqualTo(MockAddress));
            Assert.That(model.CrowdloanId, Is.EqualTo(crowdloanId));
            Assert.That(model.Amount, Is.EqualTo(expected));
        }
    }
}
