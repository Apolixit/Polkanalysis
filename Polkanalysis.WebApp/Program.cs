using Polkanalysis.Components.Services.Http;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Database;
using ApexCharts;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Staking;

namespace Polkanalysis.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddDbContext<SubstrateDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost:5432; Username=postgres; Password=test; Database=Polkanalysis");
            });
            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IApiService, ApiService>();

            builder.Services.AddPolkadotBlockchain();
            builder.Services.AddEndpoint();
            builder.Services.AddSubstrateService();
            builder.Services.AddDatabaseEvents();
            builder.Services.AddSubstrateLogic();
            builder.Services.AddMediatRAndPipelineBehaviors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
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