using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Abstract.Tests
{
    public class GlobalIntegrationTest
    {
        protected ISubstrateService _substrateService = default!;
        protected IConfigurationRoot _endpointConfiguration;
        protected ISubstrateEndpoint _substrateEndpoints;

        public GlobalIntegrationTest()
        {
            _endpointConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            _substrateEndpoints = GetEndpoint();

            if (_substrateEndpoints == null)
                throw new InvalidOperationException($"{nameof(_substrateEndpoints)} is null. You must provide a valid Substrate endpoint");
        }

        public ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfiguration = new SubstrateEndpoint(_endpointConfiguration);
            return substrateConfiguration;
        }

        public ISubstrateService GetSubstrateService()
            => _substrateService;

        
    }
}
