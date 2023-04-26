using MediatR.Courier;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Configuration.Extentions;
using Polkanalysis.Domain.UseCase.Explorer.Block;

namespace Polkanalysis.Web.Services
{
    public static class CommunicationServices
    {
        public static IServiceCollection AddCommunication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(BlockLightUseCase).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            services.AddCourier(typeof(SubscribeNewBlocksUseCase).Assembly, typeof(Program).Assembly);

            return services;
        }
    }
}
