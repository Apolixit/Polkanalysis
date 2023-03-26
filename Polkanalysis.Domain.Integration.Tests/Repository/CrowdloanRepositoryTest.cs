using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Dto;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _crowdloanRepository = new PolkadotCrowdloanRepository(_substrateRepository, _modelBuilder);
        }
    }
}
