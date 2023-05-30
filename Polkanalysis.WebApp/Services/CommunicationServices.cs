using MediatR.Courier;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using FluentValidation;
using MediatR;
using Polkanalysis.Domain.UseCase;

namespace Polkanalysis.WebApp.Services
{
    public static class CommunicationServices
    {
        public static IServiceCollection AddMediatRAndPipelineBehaviors(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(BlockLightUseCase).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            services.AddCourier(typeof(SubscribeNewBlocksUseCase).Assembly, typeof(Program).Assembly);

            services.AddValidatorsFromAssembly(typeof(BlockLightUseCase).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

            return services;
        }
    }
}
