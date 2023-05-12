
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Polkanalysis.Infrastructure.Common.Database;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using MediatR.Courier;
using MediatR;
using Polkanalysis.Domain.UseCase;
using FluentValidation;
using Polkanalysis.Domain.Adapter.Block;
using Serilog;
using Polkanalysis.Configuration.Extentions;

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
                builder.Services.TryAddSingleton<ISubstrateEndpoint, SubstrateEndpoint>();
                builder.Services.AddMediatR(cfg => {
                    cfg.RegisterServicesFromAssembly(typeof(BlockLightUseCase).Assembly);
                    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                });
                builder.Services.AddCourier(typeof(SubscribeNewBlocksUseCase).Assembly, typeof(Program).Assembly);
                builder.Services.AddDatabaseEvents();
                builder.Services.AddSingleton<ISubstrateRepository, PolkadotRepository>();
                builder.Services.AddSingleton<IExplorerRepository, PolkadotExplorerRepository>();
                builder.Services.AddSingleton<IModelBuilder, Domain.Dto.ModelBuilder>();
                builder.Services.AddSingleton<ISubstrateDecoding, SubstrateDecoding>();
                builder.Services.AddSingleton<IPalletBuilder, PalletBuilder>();
                builder.Services.AddSingleton<INodeMapping, EventNodeMapping>();
                builder.Services.AddSingleton<IBlockchainMapping, PolkadotMapping>();
                builder.Services.AddSingleton<ICurrentMetaData, CurrentMetaData>();
                builder.Services.AddSingleton<IModuleInformation, ModuleInformation>();
                builder.Services.AddSingleton<BlockParameterLike>();

                builder.Services.AddValidatorsFromAssembly(typeof(BlockLightUseCase).Assembly);

                builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
                builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

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

                await app.Services.GetRequiredService<ISubstrateRepository>().ConnectAsync();

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
                Log.Fatal(ex, "Host terminated unexpectedly !");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}