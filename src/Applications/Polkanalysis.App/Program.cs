using Polkanalysis.Components.Services.Http;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Database;
using Serilog;
using Polkanalysis.App.Components;
using Serilog.Extensions.Logging;
using Polkanalysis.Infrastructure.Database.Extensions;
using Microsoft.FluentUI.AspNetCore.Components;
using ApexCharts;
using Polkanalysis.Common.Monitoring.Opentelemetry;


var (serilogLogger, microsoftLogger, _) = Polkanalysis.Common.Start.StartApplicationExtension.InitLoggerAndConfig("Polkanalysis.App");

serilogLogger.Information("Starting Polkanalysis Web application ...");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddFluentUIComponents();

builder.Services.AddDbContext<SubstrateDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SubstrateDb"));
});

builder.Services.AddScoped<IApiService, ApiService>();

builder.Services.AddHttpClient();
builder.Services.AddPolkadotBlockchain("polkadot");
builder.Services.AddEndpoint();
builder.Services.AddSubstrateService();
builder.Services.AddSubstrateLogic();
builder.Services.AddMediatRAndPipelineBehaviors();
builder.Services.AddDatabase();

builder.Services.AddOpentelemetry(microsoftLogger,"Polkanalysis.App");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await app.ApplyMigrationAsync(new SerilogLoggerFactory(serilogLogger).CreateLogger("database"));

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<StartApp>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Polkanalysis.Components.Pages.Index).Assembly);

app.Run();
