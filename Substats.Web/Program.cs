using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Runtime;
using Substats.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Substats.Infrastructure.DirectAccess.Repository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ISubstrateRepository, PolkadotRepository>();
//builder.Services.AddScoped<IEventRepository, EventRepositoryDirectAccess>();
builder.Services.AddScoped<ISubstrateDecoding, SubstrateDecoding>();

var host = builder.Build();
var logger = host.Services.GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Application start...");

await host.RunAsync();
