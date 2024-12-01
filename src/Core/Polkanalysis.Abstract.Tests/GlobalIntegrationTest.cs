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
    public abstract class GlobalIntegrationTest
    {
        protected ISubstrateService _substrateService = default!;
        protected IConfigurationRoot _endpointConfiguration;
        protected ISubstrateEndpoint _substrateEndpoints;
        protected SubstrateDbContext _substrateDbContext = default!;
        protected IServiceProvider _serviceProvider;

        // Run unit test full or light (for the CI)
        protected static readonly string Category = Environment.GetEnvironmentVariable("CATEGORY") ?? "full";

        public GlobalIntegrationTest()
        {
            _endpointConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            _substrateEndpoints = GetEndpoint();

            if (_substrateEndpoints == null)
                throw new InvalidOperationException($"{nameof(_substrateEndpoints)} is null. You must provide a valid Substrate endpoint");

            _serviceProvider = Substitute.For<IServiceProvider>();

            _substrateService = MockSubstrateService();
        }

        /// <summary>
        /// Build a "pseudo" mock of the substrate service (Polkadot, PeopleChain, etc)
        /// </summary>
        /// <returns></returns>
        protected abstract ISubstrateService MockSubstrateService();

        public ISubstrateEndpoint GetEndpoint()
        {
            var substrateConfiguration = new SubstrateEndpoint(_endpointConfiguration);
            return substrateConfiguration;
        }

        public ISubstrateService GetSubstrateService()
            => _substrateService;


        /// <summary>
        /// Connect to the endpoint at the beggining of test
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp]
        public virtual async Task ConnectAsync()
        {
            if (_substrateService != null && !_substrateService.IsConnected())
            {
                await connectAsync();
            }
        }

        private async Task connectAsync()
        {
            try
            {
                await _substrateService.ConnectAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Node is not running : {ex.Message}");
            }
        }

        [SetUp]
        public async Task EnsureConnectedAsync()
        {
            if(_substrateService is null)
            {
                _substrateService = MockSubstrateService();
            }

            Assert.That(_substrateService, Is.Not.Null, "_substrateService is null !!!!");

            var isConnected = _substrateService.IsConnected();

            if (!isConnected)
            {
                await connectAsync();
                isConnected = _substrateService.IsConnected();
            }
            Assert.That(isConnected, Is.True, $"{_substrateService.BlockchainName} is not connected");
        }

        /// <summary>
        /// Close connection when tests are finished
        /// </summary>
        /// <returns></returns>
        [OneTimeTearDown]
        public virtual async Task DisconnectAsync()
        {
            if (_substrateService != null && _substrateService.IsConnected())
            {
                await _substrateService.CloseAsync(CancellationToken.None);
            }
        }

        /// <summary>
        /// This is use to filter tests because for CICD we don't want to run all tests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="BlockFromVersion"></param>
        /// <returns></returns>
        protected static IEnumerable<T> FilterTestCase<T>(IEnumerable<T> BlockFromVersion)
        {
            return Category == "light" ? [BlockFromVersion.First(), BlockFromVersion.Last()] : BlockFromVersion;
        }
    }
}
