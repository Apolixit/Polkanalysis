using Microsoft.EntityFrameworkCore;
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
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Worker.Parameters;
using Polkanalysis.Worker.Tasks;
using Polkanalysis.Infrastructure.Database.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Extensions;
using Polkanalysis.Common.Monitoring.Opentelemetry;
using FluentValidation;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Polkanalysis.Domain.Contracts.Metrics;
using Polkanalysis.Domain.Metrics;
using Polkanalysis.Worker;
using System.Configuration;

Microsoft.Extensions.Logging.ILogger? logger = null;

var host = Host.CreateDefaultBuilder(args)
.UseSerilog((hostingContext, service, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration).MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning))
.ConfigureServices((hostContext, services) =>
{
    var blockchainName = hostContext.Configuration["blockchainName"] ?? throw new ConfigurationErrorsException("Please provide blockchainName in args...");

    (logger, _) = Polkanalysis.Common.Start.StartApplicationExtension.InitLoggerAndConfig("Polkanalysis.Worker", hostContext.Configuration);

    logger.LogInformation("Starting Polkanalysis Worker hosted service for {blockchainName} node {wssEndpoint}...", blockchainName, hostContext.Configuration["SubstrateEndpoint:Endpoint"]);

    var workerConfig = hostContext.Configuration.GetSection("Worker").Get<WorkerConfig>() ?? throw new InvalidOperationException("Worker section is not defined in appSettings.json");

    if (workerConfig.BlocksConfig.IsEnabled)
        services.AddHostedService<BlockWorker>();

    if (workerConfig.ExtrinsicsConfig.IsEnabled)
        services.AddHostedService<ExtrinsicsWorker>();

    if (workerConfig.EventsConfig.IsEnabled)
        services.AddHostedService<EventsWorker>();

    if (workerConfig.PriceConfig.IsEnabled)
        services.AddHostedService<PriceWorker>();

    if (workerConfig.StakingConfig.IsEnabled)
        services.AddHostedService<StakingWorker>();

    if (workerConfig.VersionConfig.IsEnabled)
        services.AddHostedService<VersionWorker>();

    services
    //.AddHostedService<EventsWorker>()
    //.AddHostedService<PriceWorker>()
    //.AddHostedService<StakingWorker>()
    .AddHostedService<VersionWorker>()
    .AddSingleton(hostContext.Configuration)
    .AddDbContextFactory<SubstrateDbContext>(options =>
    {
        options.UseNpgsql(
            hostContext.Configuration.GetConnectionString("SubstrateDb")
        );
    }, ServiceLifetime.Transient)
    .AddTransient<PerimeterService>()
    .AddSingleton<IDomainMetrics, DomainMetrics>();

    services.AddEndpoint(hostContext.Configuration, true);
    services.AddSubstrateService();
    services.AddSubstrateBlockchain(blockchainName.ToLower(), true);
    services.AddDatabase();
    services.AddSubstrateLogic();
    services.AddSubstrateNodeBuilder();

    services.AddOpentelemetry(logger!,
        "Polkanalysis.Worker",
        new List<string>() { DomainMetrics.DomainMetricsName });

    services.AddHttpClient();

    services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(BlockLightHandler).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });
    services.AddCourier(typeof(SubscribeNewBlocksHandler).Assembly, typeof(Program).Assembly);
    services.AddValidatorsFromAssembly(typeof(BlockLightHandler).Assembly, ServiceLifetime.Transient);
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
})
.Build();

await host.ApplyMigrationAsync(logger!);
await host.ConnectNodeAsync("Polkanalysis.Worker", logger!, CancellationToken.None);

await host.RunAsync();


