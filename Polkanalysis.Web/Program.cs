using Polkanalysis.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polkanalysis.Web.Services;
using Polkanalysis.Components.Services.Http;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Database;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IApiService, ApiService>();

builder.Services.AddEndpoint();
builder.Services.AddSubstrateService();
builder.Services.AddDatabaseEvents();
builder.Services.AddPolkadotBlockchain();
builder.Services.AddSubstrateLogic();
builder.Services.AddMediatRAndPipelineBehaviors();

var host = builder.Build();
var logger = host.Services.GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Application start...");

await host.RunAsync();
