using MediatR;
using MediatR.Courier;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Primary.Notification;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class SubscribeNewBlocksUseCase : IRequestHandler<SubscribeBlockCommand>
    {
        private readonly IExplorerRepository _explorerRepository;
        private readonly IPublisher _publisher;
        private readonly ICourier _courier;
        private readonly ILogger<SubscribeNewBlocksUseCase> _logger;

        public SubscribeNewBlocksUseCase(
            IExplorerRepository explorerRepository, 
            IPublisher publisher, 
            ICourier courier,
            ILogger<SubscribeNewBlocksUseCase> logger)
        {
            _explorerRepository = explorerRepository;
            _publisher = publisher;
            _courier = courier;
            _logger = logger;
        }

        public async Task Handle(SubscribeBlockCommand request, CancellationToken cancellationToken)
        {
            await _explorerRepository.SubscribeNewBlocksAsync(async (BlockLightDto blockLight) =>
            {
                await _publisher.Publish(new BlockNotification()
                {
                    blockLight = blockLight
                });
            }, cancellationToken);


            _courier.SubscribeWeak<BlockNotification>(HandleBlockAsync);
            //await Task.CompletedTask;
        }

        public Task HandleBlockAsync(BlockNotification notification, CancellationToken cancellationToken)
        {
            //Console.WriteLine(notification.blockLight.Number);
            //_logger.LogInformation("New block handle !");

            return Task.CompletedTask;
        }

    }
}
