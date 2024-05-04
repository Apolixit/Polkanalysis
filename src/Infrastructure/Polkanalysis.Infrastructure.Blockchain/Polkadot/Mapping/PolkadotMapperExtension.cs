using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping.PolkadotMapping;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping
{
    [ExcludeFromCodeCoverage]
    public static class PolkadotMapperExtension
    {
        public static IServiceCollection AddPolkadotMapper(this IServiceCollection services)
        {
            services.AddTransient<IBlockchainMapping, PolkadotMapping>();
            return services;
        }
    }
}
