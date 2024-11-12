using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Integration.Tests.PeopleChain
{
    public class PeopleChainIntegrationTest : DomainIntegrationTest
    {
        public PeopleChainIntegrationTest() : base()
        {
        }

        protected override ISubstrateService MockSubstrateService()
        {
            return new PeopleChainService(
                _substrateEndpoints,
                new PeopleChainMapping(Substitute.For<ILogger<PeopleChainMapping>>()),
                Substitute.For<ILogger<PeopleChainService>>());
        }
    }
}
