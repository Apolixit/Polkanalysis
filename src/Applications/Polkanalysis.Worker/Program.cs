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
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Worker.Parameters.Context;
using Polkanalysis.Worker.Parameters;
using Polkanalysis.Worker.Tasks;
using Serilog.Extensions.Logging;
using Polkanalysis.Infrastructure.Database.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Extensions;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

var logger = new LoggerConfiguration().ReadFrom.Configuration(config)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
    .CreateLogger();

logger.Information("Starting Polkanalysis Worker hosted service...");

var host = Host.CreateDefaultBuilder(args)
.UseSerilog(logger)
.ConfigureServices((hostContext, services) =>
{
    services
    .AddHostedService<EventsWorker>()
    //.AddHostedService<PriceWorker>()
    //.AddHostedService<StakingWorker>()
    //.AddHostedService<VersionWorker>()
    .AddSingleton(config)
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
    .AddTransient<PerimeterService>();
    //.AddScoped<EventsWorker>()
    //.AddScoped<StakingWorker>()
    //.AddScoped<VersionWorker>()
    //.AddScoped<PriceWorker>();

    services.AddEndpoint(true);
    services.AddSubstrateService();
    services.AddPolkadotBlockchain("polkadot", true);
    services.AddDatabase();
    services.AddSubstrateLogic();

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

Microsoft.Extensions.Logging.ILogger log = new SerilogLoggerFactory(logger).CreateLogger("database");
await host.ApplyMigrationAsync(log);
await host.ConnectNodeAsync("Polkanalysis.Worker", log);

await host.RunAsync();


