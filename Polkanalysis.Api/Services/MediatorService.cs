using FluentValidation;
using MediatR.Courier;
using MediatR;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Polkanalysis.Domain.UseCase;

namespace Polkanalysis.Api.Services
{
    public static class MediatorService
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
