using Polkanalysis.Components.Services.Http;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
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
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Polkanalysis.Domain.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
var (microsoftLogger, serilogLogger) = Polkanalysis.Common.Start.StartApplicationExtension.InitLoggerAndConfig("Polkanalys.App", builder.Configuration);
builder.Host.UseSerilog(serilogLogger);

microsoftLogger.LogInformation("Starting Polkanalysis Web application");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddFluentUIComponents();

builder.Services.AddDbContext<SubstrateDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SubstrateDb"));
});

builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ITooltipService, TooltipService>();

builder.Services.AddSubstrateBlockchain("polkadot");
builder.Services.AddEndpoint(builder.Configuration);
builder.Services.AddSubstrateService();
builder.Services.AddSubstrateLogic();
builder.Services.AddSubstrateNodeBuilder();
builder.Services.AddMediatRAndPipelineBehaviors();
builder.Services.AddDatabase();

builder.Services.AddDataGridEntityFrameworkAdapter();

builder.Services.AddOpentelemetry(microsoftLogger, "Polkanalysis.App", new List<string>() { DomainMetrics.DomainMetricsName });

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

await app.ApplyMigrationAsync(microsoftLogger);

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<StartApp>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Polkanalysis.Components.Pages.Contact).Assembly);

await app.RunAsync();
