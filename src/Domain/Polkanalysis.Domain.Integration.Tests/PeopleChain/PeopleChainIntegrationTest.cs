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

namespace Polkanalysis.Domain.Integration.Tests.PeopleChain
{
    public class PeopleChainIntegrationTest : DomainIntegrationTest
    {
        public PeopleChainIntegrationTest() : base()
        {
            _substrateService = new PeopleChainService(
                _substrateEndpoints,
                new PeopleChainMapping(Substitute.For<ILogger<PeopleChainMapping>>()),
                Substitute.For<ILogger<PeopleChainService>>());
        }
        //public string PeopleChainEndpointUri => "wss://rpc-people-polkadot.luckyfriday.io";

        //internal override ISubstrateEndpoint GetEndpoint()
        //{
        //    var substrateConfiguration = new SubstrateEndpoint(_endpointConfiguration);
        //    return substrateConfiguration;
        //}
    }
}
