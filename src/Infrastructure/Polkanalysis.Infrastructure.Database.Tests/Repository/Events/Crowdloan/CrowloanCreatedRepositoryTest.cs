using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Crowdloan
{
    internal class CrowloanCreatedRepositoryTest : EventsDatabaseTests
    {
        private CrowdloanCreatedRepository _crowloanCreatedRepository;

        [SetUp]
        public void Setup()
        {
            _crowloanCreatedRepository = new CrowdloanCreatedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<CrowdloanCreatedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventCrowdloanCreated.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "", "", 1));
            _substrateDbContext.EventCrowdloanCreated.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "", "", 2));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_crowloanCreatedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(10u)]
        public async Task BuildModel_WhenValidCrowdloanCreation_ShouldBuildModelSuccessfullyAsync(uint crowdloanId)
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

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _crowloanCreatedRepository.SearchAsync(new()
            {
                CrowdloanId = NumberCriteria<uint>.Equal(4),
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(0));
        }
    }
}
