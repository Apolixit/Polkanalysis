using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Database;
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
        protected SubstrateDbContext _substrateDbContext = default!;
        protected IServiceProvider _serviceProvider;

        public GlobalIntegrationTest()
        {
            _endpointConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            _substrateEndpoints = GetEndpoint();

            if (_substrateEndpoints == null)
                throw new InvalidOperationException($"{nameof(_substrateEndpoints)} is null. You must provide a valid Substrate endpoint");

            _serviceProvider = Substitute.For<IServiceProvider>();
        }

        public ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfiguration = new SubstrateEndpoint(_endpointConfiguration);
            return substrateConfiguration;
        }

        public ISubstrateService GetSubstrateService()
            => _substrateService;


        //[SetUp]
        //protected void Setup()
        //{
        //    _serviceProvider.GetService(typeof(IDelegateSystemChain)).Returns(new DelegateSystemChain(_substrateService, _substrateDbContext, Substitute.For<ILogger<DelegateSystemChain>>()));
        //}
    }
}
