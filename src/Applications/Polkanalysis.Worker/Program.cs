﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Domain.Runtime;
using Serilog;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using MediatR.Courier;
using MediatR;
using Polkanalysis.Domain.UseCase;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Worker.Parameters;
using Polkanalysis.Worker.Tasks;
using Polkanalysis.Infrastructure.Database.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Extensions;
using Polkanalysis.Common.Monitoring.Opentelemetry;
using Polkanalysis.Worker.Metrics;

Microsoft.Extensions.Logging.ILogger? logger = null;

var host = Host.CreateDefaultBuilder(args)
.UseSerilog()
.ConfigureServices((hostContext, services) =>
{
    logger = Polkanalysis.Common.Start.StartApplicationExtension.InitLoggerAndConfig("Polkanalysis.Worker", hostContext.Configuration);

    logger.LogInformation("Starting Polkanalysis Worker hosted service...");

    services
    //.AddHostedService<EventsWorker>()
    //.AddHostedService<PriceWorker>()
    .AddHostedService<StakingWorker>()
    //.AddHostedService<VersionWorker>()
    .AddSingleton(hostContext.Configuration)
    .AddDbContextFactory<SubstrateDbContext>(options =>
    {
        options.UseNpgsql(
            hostContext.Configuration.GetConnectionString("SubstrateDb")
        );
    }, ServiceLifetime.Transient)
    .AddLogging(l =>
    {
        l.ClearProviders();
        l.AddConsole();
        l.SetMinimumLevel(LogLevel.Information);
        l.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
    })
    .AddTransient<PerimeterService>()
    .AddSingleton<WorkerMetrics>();

    services.AddEndpoint(hostContext.Configuration, true);
    services.AddSubstrateService();
    services.AddPolkadotBlockchain("polkadot", true);
    services.AddDatabase();
    services.AddSubstrateLogic();

    services.AddOpentelemetry(logger, 
        "Polkanalysis.Worker", 
        new List<string>() { "Polkanalysis.Worker.Metrics" });

    services.AddHttpClient();

    services.AddMediatR(cfg => {
        cfg.RegisterServicesFromAssembly(typeof(BlockLightHandler).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });
    services.AddCourier(typeof(SubscribeNewBlocksHandler).Assembly, typeof(Program).Assembly);

    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
})
.Build();

await host.ApplyMigrationAsync(logger!);
await host.ConnectNodeAsync("Polkanalysis.Worker", logger!);

await host.RunAsync();


