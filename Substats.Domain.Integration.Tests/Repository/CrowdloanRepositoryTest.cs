using NUnit.Framework;
using Substats.Domain.Contracts.Dto;
using Substats.Domain.Contracts.Secondary.Repository;
using Substats.Domain.Dto;
using Substats.Domain.Repository;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Integration.Tests.Repository
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
