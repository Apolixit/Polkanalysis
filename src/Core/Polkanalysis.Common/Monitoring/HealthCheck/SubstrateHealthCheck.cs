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

        /// <summary>
        /// Check if we are connected and if it is not too laggy
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if(_substrateService.IsConnected())
            {
                var elapsedTime = await _substrateService.PingAsync(cancellationToken);

                if(elapsedTime < 100)
                {
                    return HealthCheckResult.Healthy();
                } else
                {
                    return HealthCheckResult.Degraded(description: $"{_substrateService.BlockchainName} lag is greater than 100ms (currently {elapsedTime})");
                }
                
            } else
            {
                return HealthCheckResult.Unhealthy(description: $"{_substrateService.BlockchainName} is not currently connected");
            }
        }
    }
}
