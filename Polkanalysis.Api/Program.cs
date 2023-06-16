
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Runtime;
using Serilog;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using Polkanalysis.Api.Services;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Host.UseSerilog(logger);
                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddRouting(options =>
                {
                    options.LowercaseUrls = true;
                    options.LowercaseQueryStrings = true;
                });

                builder.Services.AddDbContext<SubstrateDbContext>(options =>
                {
                    options.UseNpgsql("Host=localhost:5432; Username=postgres; Password=test; Database=Polkanalysis");
                });

                builder.Services.AddMediatRAndPipelineBehaviors();

                builder.Services.AddEndpoint();
                builder.Services.AddSubstrateService();
                builder.Services.AddDatabaseEvents();
                builder.Services.AddPolkadotBlockchain();
                builder.Services.AddSubstrateLogic();

                //builder.Services.AddDatabaseEvents();
                //builder.Services.AddSingleton<ISubstrateRepository, PolkadotRepository>();

                //builder.Services.AddSubstrateRepositories();

                //builder.Services.AddSingleton<IModelBuilder, Domain.Runtime.ModelBuilder>();
                //builder.Services.AddSingleton<ISubstrateDecoding, SubstrateDecoding>();
                //builder.Services.AddSingleton<IPalletBuilder, PalletBuilder>();
                //builder.Services.AddSingleton<INodeMapping, EventNodeMapping>();
                //builder.Services.AddSingleton<IBlockchainMapping, PolkadotMapping>();
                //builder.Services.AddSingleton<ICurrentMetaData, CurrentMetaData>();
                //builder.Services.AddSingleton<IModuleInformation, ModuleInformation>();
                //builder.Services.AddSingleton<BlockParameterLike>();

                

                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(
                                      policy =>
                                      {
                                          policy.AllowAnyOrigin();
                                          policy.AllowAnyHeader();
                                          policy.AllowAnyMethod();
                                      });
                });

                var app = builder.Build();

                var substrateService = app.Services.GetRequiredService<ISubstrateService>();
                await substrateService.ConnectAsync();
                if(substrateService.IsConnected())
                {
                    logger.Information($"Polkanalysis.API is now connected to {substrateService.BlockchainName} !");
                } else
                {
                    logger.Error($"Polkanalysis.API is unable to connected to {substrateService.BlockchainName} !");
                }
                

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.UseCors();
                app.MapControllers();

                await app.RunAsync();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Host terminated unexpectedly !");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}