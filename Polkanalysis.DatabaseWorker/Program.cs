using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.DatabaseWorker;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Common.Database;
using Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Common.Database.Repository;
using Polkanalysis.Infrastructure.Contracts;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Configuration.Extentions;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Polkanalysis.DatabaseWorker.Parameters;
using Serilog;
using Prometheus;

IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

var logger = new LoggerConfiguration().ReadFrom.Configuration(config)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
    .CreateLogger();

var host = Host.CreateDefaultBuilder(args)
.UseSerilog(logger)
.ConfigureServices((hostContext, services) =>
{
    services
    .AddHostedService<EventsWorker>()
    .AddSingleton(config)
    .AddDbContext<SubstrateDbContext>(options =>
    {
        options.UseNpgsql(
            hostContext.Configuration.GetConnectionString("SubstrateDb")
        );
    })
    .AddLogging(l =>
    {
        l.ClearProviders();
        l.AddConsole();
        l.SetMinimumLevel(LogLevel.Information);
        l.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
    })
    .AddSingleton<ISubstrateRepository, PolkadotRepository>()
    .AddSingleton<PolkadotMapping>()
    .AddSingleton<IExplorerRepository, ExplorerRepository>()
    .AddSingleton<ISubstrateEndpoint, SubstrateEndpoint>()
    .AddSingleton<ISubstrateDecoding, SubstrateDecoding>()
    .AddSingleton<IPalletBuilder, PalletBuilder>()
    .AddSingleton<INodeMapping, EventNodeMapping>()
    .AddSingleton<IBlockchainMapping, PolkadotMapping>()
    .AddSingleton<IEventAggregateRepository, EventAggregateRepository>()
    .AddSingleton<ICurrentMetaData, CurrentMetaData>()
    .AddSingleton<IEventsFactory, EventsFactory>()
    .AddSingleton<IModelBuilder, Polkanalysis.Domain.Runtime.ModelBuilder>()
    .AddSingleton<BlockPerimeter>()
    .AddDatabaseEvents();
})
.Build();

await host.RunAsync();


