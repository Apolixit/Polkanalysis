using Microsoft.Extensions.Diagnostics.HealthChecks;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Common.Monitoring.HealthCheck
{
    public class SubstrateHealthCheck : IHealthCheck
    {
        private readonly ISubstrateService _substrateService;

        public SubstrateHealthCheck(ISubstrateService substrateService)
        {
            _substrateService = substrateService;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if(_substrateService.IsConnected())
            {
                return Task.FromResult(HealthCheckResult.Healthy());
            } else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }
        }
    }
}
