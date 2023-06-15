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
using Polkanalysis.Infrastructure.Polkadot.Repository;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using MediatR.Courier;
using MediatR;
using Polkanalysis.Domain.UseCase;

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
    .AddHostedService<MainWorker>()
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
    .AddSingleton<BlockPerimeter>()
    .AddSingleton<EventsWorker>()
    .AddSingleton<PriceWorker>();

    services.AddEndpoint();
    services.AddSubstrateRepositories();
    services.AddPolkadotBlockchain();
    services.AddDatabaseEvents();
    services.AddSubstrateLogic();

    services.AddHttpClient();

    services.AddMediatR(cfg => {
        cfg.RegisterServicesFromAssembly(typeof(BlockLightUseCase).Assembly);
        cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });
    services.AddCourier(typeof(SubscribeNewBlocksUseCase).Assembly, typeof(Program).Assembly);

    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
})
.Build();

await host.RunAsync();


