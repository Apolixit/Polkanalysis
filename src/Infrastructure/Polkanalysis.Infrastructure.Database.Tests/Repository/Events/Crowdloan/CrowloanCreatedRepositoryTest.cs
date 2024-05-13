using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Crowdloan
{
    internal class CrowloanCreatedRepositoryTest : EventsDatabaseTests
    {
        private CrowloanCreatedRepository _crowloanCreatedRepository;

        [SetUp]
        public void Setup()
        {
            _crowloanCreatedRepository = new CrowloanCreatedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<CrowloanCreatedRepository>>());
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_crowloanCreatedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(10)]
        public async Task BuildModel_WhenValidCrowdloanCreation_ShouldBuildModelSuccessfullyAsync(int crowdloanId)
        {
            var enumContribution = new Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent();
            enumContribution.Create(Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.Event.Created, new Id((uint)crowdloanId));

            var model = await _crowloanCreatedRepository.BuildModelAsync(
                BuildEventModel("Crowdloan", moduleEvent: "Created"),
                enumContribution,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Crowdloan"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Created"));
            Assert.That(model.CrowdloanId, Is.EqualTo(crowdloanId));
        }
    }
}
