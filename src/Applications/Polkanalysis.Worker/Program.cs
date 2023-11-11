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
    .AddScoped<PerimeterService>()
    .AddScoped<EventsWorker>()
    .AddScoped<StakingWorker>()
    .AddScoped<VersionWorker>()
    .AddScoped<PriceWorker>();

    services.AddEndpoint();
    services.AddSubstrateService();
    services.AddPolkadotBlockchain("polkadot");
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

logger.Information("Waiting 20s to ensure database is created...");
Thread.Sleep(20_000);

await host.RunAsync();


