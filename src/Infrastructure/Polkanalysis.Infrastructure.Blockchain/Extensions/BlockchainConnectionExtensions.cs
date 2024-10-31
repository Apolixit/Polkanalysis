using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Extensions
{
    public static class BlockchainConnectionExtensions
    {
        public static async Task<IHost> ConnectNodeAsync(this IHost host, string appName, ILogger logger, CancellationToken cancellationToken)
        {
            var substrateService = host.Services.GetRequiredService<ISubstrateService>();
            await substrateService.ConnectAsync(cancellationToken);
            if (substrateService.IsConnected())
            {
                logger.LogInformation("[{appName}] is now connected to {blockchainName} and ready to serve.", appName, substrateService.BlockchainName);
            }
            else
            {
                logger.LogError("[{appName}] is unable to connected to {blockchainName} !", appName, substrateService.BlockchainName);
            }

            return host;
        }
    }
}
