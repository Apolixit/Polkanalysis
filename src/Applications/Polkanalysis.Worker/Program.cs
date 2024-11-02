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

Microsoft.Extensions.Logging.ILogger? logger = null;

var host = Host.CreateDefaultBuilder(args)
.UseSerilog((hostingContext, service, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration).MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning))
.ConfigureServices((hostContext, services) =>
{
    var blockchainName = args[0] is null || args[0] == "--applicationName" ? "polkadot" : args[0];

    (logger, _) = Polkanalysis.Common.Start.StartApplicationExtension.InitLoggerAndConfig("Polkanalysis.Worker", hostContext.Configuration);

    logger.LogInformation("Starting Polkanalysis Worker hosted service for {blockchainName} node {wssEndpoint}...", blockchainName, hostContext.Configuration["SubstrateEndpoint:Endpoint"]);

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


