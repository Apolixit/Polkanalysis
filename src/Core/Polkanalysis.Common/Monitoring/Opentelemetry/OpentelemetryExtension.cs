using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Configuration.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Common.Monitoring.Opentelemetry
{
    [ExcludeFromCodeCoverage]
    public static class OpentelemetryExtension
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/core/diagnostics/observability-with-otel
        /// https://github.com/Azure/azure-sdk-for-net/blob/d51f02c6ef46f2c5d9b38a9d8974ed461cde9a81/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/src/OpenTelemetryBuilderExtensions.cs#L80
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddOpentelemetry(
            this IServiceCollection services,
            ILogger logger,
            string ressourceBuilderServiceName,
            IEnumerable<string>? customMetricsName = null,
            IEnumerable<string>? customTracesName = null)
        {
            services.AddTransient<IMonitoringEndpoint, MonitoringEndpoint>();

            logger.LogInformation("Starting register OpenTelemetry");

            // Get the OTEL endpoint from the configuration
            string? otlpEndpoint = null;
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var otlpConfiguration = serviceProvider.GetService<IMonitoringEndpoint>();

                if (otlpConfiguration is not null && otlpConfiguration.OpentelemetryUri is not null)
                    otlpEndpoint = otlpConfiguration.OpentelemetryUri.OriginalString;
            }

            var otel = services.AddOpenTelemetry().ConfigureResource(ressource => ressource.AddService(ressourceBuilderServiceName));

            otel.WithMetrics(metrics =>
            {
                metrics.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(ressourceBuilderServiceName));

                // If we have some custom metrics, we add them
                if (customMetricsName is not null && customMetricsName.Any())
                {
                    foreach (var customMetric in customMetricsName)
                    {
                        metrics.AddMeter(customMetric);
                    }
                }

                metrics
                .AddAspNetCoreInstrumentation()
                .AddRuntimeInstrumentation()
                .AddProcessInstrumentation()
                .AddMeter("Microsoft.AspNetCore.Hosting")
                .AddMeter("Microsoft.AspNetCore.Server.Kestrel");

                //metrics.AddOtlpExporter(otlpOptions =>
                //{
                //    otlpOptions.Endpoint = new Uri("http://localhost:4317");

                //});

                if (!string.IsNullOrEmpty(otlpEndpoint))
                {
                    metrics.AddOtlpExporter(otlpOptions =>
                    {
                        otlpOptions.Endpoint = new Uri(otlpEndpoint);
                    });
                }

                //.AddPrometheusExporter(); // OpenTelemetry.Exporter.Prometheus.AspNetCore
            });

            otel.WithTracing(tracing =>
            {
                // Custom traces sent by parent application
                if (customTracesName is not null && customTracesName.Any())
                {
                    foreach (var customTrace in customTracesName)
                    {
                        tracing.AddSource(customTrace);
                    }
                }

                tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation();

                //tracing.AddOtlpExporter(otlpOptions =>
                //{
                //    otlpOptions.Endpoint = new Uri("http://localhost:4317");
                //    });

                if (!string.IsNullOrEmpty(otlpEndpoint))
                {
                    tracing.AddOtlpExporter(otlpOptions =>
                    {
                        otlpOptions.Endpoint = new Uri(otlpEndpoint);
                    });
                }

                tracing.AddConsoleExporter();
            });



            //services.ConfigureOpenTelemetryMeterProvider((sp, builder) => builder.AddRuntimeInstrumentation());

            return services;
        }
    }
}
