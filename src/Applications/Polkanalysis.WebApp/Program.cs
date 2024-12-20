using Polkanalysis.Components.Services.Http;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Database;
using Serilog;
using Microsoft.FluentUI.AspNetCore.Components;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

namespace Polkanalysis.WebApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();

            logger.Information("Starting Polkanalysis Web application ...");
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog(logger);

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
            builder.Services.AddSubstrateBlockchain("polkadot");
            builder.Services.AddEndpoint(builder.Configuration);
            builder.Services.AddSubstrateService();
            builder.Services.AddDatabase();
            builder.Services.AddSubstrateLogic();
            builder.Services.AddSubstrateNodeBuilder();
            builder.Services.AddMediatRAndPipelineBehaviors();

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            } else {
                //logger.Information("Waiting 20s to ensure database is created...");
                //Thread.Sleep(20_000);
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}