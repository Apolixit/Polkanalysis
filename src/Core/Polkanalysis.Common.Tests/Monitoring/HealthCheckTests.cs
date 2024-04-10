using Microsoft.Extensions.Diagnostics.HealthChecks;
using NSubstitute;
using Polkanalysis.Common.Monitoring.HealthCheck;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Common.Tests.Monitoring
{
    public class HealthCheckTests
    {
        private ISubstrateService _substrateService;

        [SetUp]
        public void Setup()
        {
            _substrateService = Substitute.For<ISubstrateService>();
        }

        [Test]
        public async Task CheckHealthAsync_WhenSubstrateServiceIsConnected_ReturnsHealthyAsync()
        {
            _substrateService.IsConnected().Returns(true);

            var healthCheck = new SubstrateHealthCheck(_substrateService);
            var context = new HealthCheckContext();

            var result = await healthCheck.CheckHealthAsync(context);

            Assert.That(result.Status, Is.EqualTo(HealthStatus.Healthy));
        }

        [Test]
        public async Task CheckHealthAsync_WhenSubstrateServiceIsNotConnected_ReturnsUnhealthyAsync()
        {
            _substrateService.IsConnected().Returns(false);

            var healthCheck = new SubstrateHealthCheck(_substrateService);
            var context = new HealthCheckContext();

            var result = await healthCheck.CheckHealthAsync(context);

            Assert.That(result.Status, Is.EqualTo(HealthStatus.Unhealthy));
        }
    }
}
