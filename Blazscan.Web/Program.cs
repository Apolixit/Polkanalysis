using Blazscan.Domain.Contracts.Repository;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.SubstrateDecode;
using Blazscan.SubstrateDecode.Abstract;
using Blazscan.SubstrateDecode.Event;
using Blazscan.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ISubstrateNodeRepository, SubstrateNodeRepositoryDirectAccess>();
builder.Services.AddScoped<IEventRepository, EventRepositoryDirectAccess>();
builder.Services.AddScoped<ISubstrateDecoding, SubstrateDecoding>();

var host = builder.Build();
var logger = host.Services.GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Application start...");

await host.RunAsync();
