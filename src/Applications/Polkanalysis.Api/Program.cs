
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Domain.Runtime;
using Serilog;
using Polkanalysis.Configuration.Extensions;
using Polkanalysis.Api.Services;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Database;
using Microsoft.AspNetCore.RateLimiting;
using System.Text.Json.Serialization;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Extensions;
using Polkanalysis.Common.Monitoring.Opentelemetry;
using Polkanalysis.Infrastructure.Blockchain.Polkadot;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Polkanalysis.Api.Filters;
using Polkanalysis.Configuration.Contracts.Api;
using Polkanalysis.Common.Monitoring.HealthCheck;
using System.Configuration;
using Polkanalysis.Hub;
using Microsoft.AspNetCore.SignalR.Client;

namespace Polkanalysis.Api
{
    public static class Program
    {
        public async static Task Main(string[] args)
        {
            Microsoft.Extensions.Logging.ILogger microsoftLogger = default!;
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                var blockchainName = builder.Configuration["blockchainName"] ?? throw new ConfigurationErrorsException("Please provide blockchainName in args...");

                var (microsftLogger, serilogLogger) = Common.Start.StartApplicationExtension.InitLoggerAndConfig($"Polkanalys.Api.{blockchainName}", builder.Configuration);
                microsoftLogger = microsftLogger;
                builder.Host.UseSerilog(serilogLogger);
                
                microsftLogger.LogInformation("Starting Polkanalysis API");

                // Add services to the container.

                // Manage controllers visibility depend of the blockchain
                var controllerVisibility = new ApiVisibility(builder.Configuration).GetAvailableController(blockchainName).ToArray();

                builder.Services.AddControllers(options =>
                {
                    options.Filters.Add(new ControllerVisibilityFilter(controllerVisibility));
                    options.Conventions.Add(new DynamicRouteConvention(blockchainName));
                }).AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddOpenApiDocument(options =>
                {
                    options.DocumentProcessors.Add(new ControllerVisibilityDocumentProcessor(controllerVisibility));
                    options.PostProcess = document =>
                    {
                        document.Info = new NSwag.OpenApiInfo()
                        {
                            Title = $"Polkanalysis API for {blockchainName.ToUpper()}",
                            Version = "v1",
                            Description = $"A RESTful API that provides information about the {blockchainName.ToUpper()} blockchain.",
                        };
                    };
                });
                builder.Services.AddRouting(options =>
                {
                    options.LowercaseUrls = true;
                    options.LowercaseQueryStrings = true;
                });

                builder.Services.AddDbContext<SubstrateDbContext>(options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString("SubstrateDb"));
                }, contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

                // For the API, we register Polkadot as singleton
                builder.Services.AddSubstrateBlockchain(blockchainName, registerAsSingleton: true);
                builder.Services.AddHttpClient();
                builder.Services.AddEndpoint(builder.Configuration, registerAsSingleton: true);
                builder.Services.AddSubstrateService();
                builder.Services.AddEventsDatabaseRepositories();
                builder.Services.AddSubstrateLogic();
                builder.Services.AddSubstrateNodeBuilder();
                builder.Services.AddMediatRAndPipelineBehaviors();
                builder.Services.AddSingleton<IApiVisibility, ApiVisibility>();

                builder.Services.AddPolkanalysisSignalRServices(builder.Configuration);

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

                builder.Services.AddOpentelemetry(microsftLogger, $"Polkanalysis.API.{blockchainName}", new List<string>() { Domain.Metrics.DomainMetrics.DomainMetricsName });
                builder.Services.AddPolkanalysisHealthChecks();

                #region API Rate limiter
                // Doc : https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit

                builder.Services.Configure<ApiRateLimitOptions>(builder.Configuration.GetSection(ApiRateLimitOptions.ApiRateLimit));
                var rateLimitOptions = new ApiRateLimitOptions();
                builder.Configuration.GetSection(ApiRateLimitOptions.ApiRateLimit).Bind(rateLimitOptions);

                // This FixedWindowLimiter will be use for CoinGecko API to avoid exceed to free quota limit
                builder.Services.AddRateLimiter(_ =>
                    _.AddFixedWindowLimiter(policyName: ApiRateLimitOptions.FixedPolicy, options =>
                    {
                        // A maximum of "NbMaxRequests" requests every "Frequency" seconds
                        options.PermitLimit = rateLimitOptions.NbMaxRequests;

                        // Period of refresh limit rate
                        options.Window = TimeSpan.FromSeconds(rateLimitOptions.Frequency);

                        // When token are now available, the process applies to give token to client in the queue
                        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;

                        // Maximum client in the queue when no tokens are available
                        options.QueueLimit = rateLimitOptions.QueueLimit;
                    }));

                // This TokenBucketLimiter will be use for general API calls
                builder.Services.AddRateLimiter(_ =>
                    _.AddTokenBucketLimiter(policyName: ApiRateLimitOptions.TokenBucketPolicy, options =>
                    {
                        // Nb maximum tokens available
                        options.TokenLimit = rateLimitOptions.TokenLimit;

                        // When token are now available, the process applies to give token to client in the queue
                        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;

                        // Maximum client in the queue when no tokens are available
                        options.QueueLimit = rateLimitOptions.QueueLimit;

                        // Frequence tokens will be refreshed
                        options.ReplenishmentPeriod = TimeSpan.FromSeconds(rateLimitOptions.ReplenishmentPeriod);

                        // Nb token added every "ReplenishmentPeriod" period
                        options.TokensPerPeriod = rateLimitOptions.TokensPerPeriod;

                        // If "AutoReplenishment" is set to true, tokens will be replenish every "ReplenishmentPeriod" period
                        options.AutoReplenishment = rateLimitOptions.AutoReplenishment;
                    }));
                #endregion

                var app = builder.Build();

                // Swagger will be available even in production, but not for now (need first release)
                if (app.Environment.IsDevelopment())
                {
                    app.UseOpenApi();
                    app.UseSwaggerUi();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.UseCors();
                app.MapControllers();

                app.MapHealthChecks("/health");
                app.UseRateLimiter();
                app.MapDefaultControllerRoute().RequireRateLimiting(ApiRateLimitOptions.TokenBucketPolicy);

                await app.ApplyMigrationAsync(microsftLogger);

                var substrateService = app.Services.GetRequiredService<ISubstrateService>();
                await substrateService.ConnectAsync(CancellationToken.None);
                if (substrateService.IsConnected())
                {
                    microsftLogger.LogInformation($"Polkanalysis.API is now connected to {substrateService.BlockchainName} and ready to serve.");
                }
                else
                {
                    microsftLogger.LogError($"Polkanalysis.API is unable to connected to {substrateService.BlockchainName} !");
                }

                microsftLogger.LogInformation("Polkanalysis.API is started for {blockchainName} and listening on {url}", blockchainName, string.Join(", ", app.Urls));

                await app.RunAsync();
            }
            catch (Exception ex)
            {
                microsoftLogger.LogError($"{ex.Message}");
            }
            finally
            {
                await Log.CloseAndFlushAsync();
            }
        }
    }
}