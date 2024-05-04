using MediatR.Courier;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using FluentValidation;
using MediatR;
using Polkanalysis.Domain.UseCase;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.WebApp.Services
{
    public static class CommunicationServices
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddMediatRAndPipelineBehaviors(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(BlockLightHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            services.AddCourier(typeof(SubscribeNewBlocksHandler).Assembly, typeof(Program).Assembly);

            services.AddValidatorsFromAssembly(typeof(BlockLightHandler).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

            return services;
        }
    }
}
