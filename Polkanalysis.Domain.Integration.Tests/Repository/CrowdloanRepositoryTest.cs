using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Integration.Tests.Contracts;

namespace Polkanalysis.Domain.Integration.Tests.Repository
{
    public class CrowdloanRepositoryTest : PolkadotIntegrationTest
    {
        private ICrowdloanRepository _crowdloanRepository;
        private IModelBuilder _modelBuilder;

        [SetUp]
        public void Setup()
        {
            _modelBuilder = new ModelBuilder();
            _crowdloanRepository = new PolkadotCrowdloanRepository(
                _substrateRepository, 
                _modelBuilder, 
                Substitute.For<IExplorerRepository>(),
                Substitute.For<IAccountRepository>());
        }
    }
}
