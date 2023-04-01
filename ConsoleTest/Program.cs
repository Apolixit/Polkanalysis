using Ajuna.NetApi.Model.Extrinsics;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Configuration.Extentions;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Dto;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated;
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
            l.SetMinimumLevel(LogLevel.Debug);
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
            .AddSingleton<PolkadotMapping>()
            .AddSingleton<ISubstrateRepository, PolkadotRepository>()
            .AddSingleton<IExplorerRepository, PolkadotExplorerRepository>()
            .AddSingleton<IModelBuilder, ModelBuilder>()
            .AddSingleton<ISubstrateEndpoint, SubstrateEndpoint>()
            .AddSingleton<ISubstrateDecoding, SubstrateDecoding>()
            .AddSingleton<IPalletBuilder, PalletBuilder>()
            .AddSingleton<IMapping, EventMapping>()
            .AddSingleton<IBlockchainMapping, PolkadotMapping>()
            .AddSingleton<ICurrentMetaData, CurrentMetaData>();
    }
}
