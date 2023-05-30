using Polkanalysis.Components.Services.Http;
using Polkanalysis.Configuration.Extentions;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Infrastructure.Polkadot.Repository;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.WebApp.Services;
using Polkanalysis.Infrastructure.Common.Database;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddEndpoint();
            builder.Services.AddSubstrateRepositories();
            builder.Services.AddPolkadotBlockchain();
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