using Ajuna.NetApi.Model.Extrinsics;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Substats.Configuration.Contracts;
using Substats.Configuration.Extentions;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest;

public class Program
{
    async static Task Main(string[] args)
    {
        //var client = new SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default());
        //await client.ConnectAsync();
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var services = new ServiceCollection();
        services.AddLogging(l =>
        {
            l.ClearProviders();
            l.AddConsole();
        });
        services.AddSingleton(config);
        ConfigureServices(services);

        var serviceProvider = services
            .AddSingleton<IRuntime, Runtime>()
            .BuildServiceProvider();

        await serviceProvider
            .GetService<IRuntime>()
            .TodoAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<SubstrateMapper>()
            .AddSingleton<ISubstrateRepository, PolkadotRepository>()
            .AddSingleton<ISubstrateEndpoint, SubstrateEndpoint>();
    }
}
