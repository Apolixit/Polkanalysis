using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using MediatR.Courier;
using MediatR;
using Polkanalysis.Domain.UseCase;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Database;

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

        //await serviceProvider.GetRequiredService<IMediator>().Send(new SubscribeBlockCommand());

        await serviceProvider
            .GetService<IRuntime>()
            .TodoAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpoint();
        services.AddSubstrateService();
        services.AddPolkadotBlockchain();
        services.AddDatabaseEvents();
        services.AddSubstrateLogic();

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(BlockLightHandler).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        services.AddCourier(typeof(SubscribeNewBlocksHandler).Assembly, typeof(Program).Assembly);

        //services.AddValidatorsFromAssembly(typeof(BlockLightUseCase).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
    }
}
