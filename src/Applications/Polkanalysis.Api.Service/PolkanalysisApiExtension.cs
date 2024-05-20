using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Api.Service
{
    public static class PolkanalysisApiExtension
    {
        public static IServiceCollection AddPolkanalysisClient(
            this IServiceCollection services)
        {
            //services.AddHttpClient<PolkanalysisApiService>();

            return services;
            //.AddTransientHttpErrorPolicy(policyBuilder =>
            //    policyBuilder.RetryAsync(3))
            //.AddTransientHttpErrorPolicy(policyBuilder =>
            //    policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
        }
    }
}
