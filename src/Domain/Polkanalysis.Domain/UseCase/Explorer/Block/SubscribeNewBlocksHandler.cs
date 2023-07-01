using MediatR;
using MediatR.Courier;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Primary.Notification;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class SubscribeNewBlocksHandler : IRequestHandler<SubscribeBlockCommand>
    {
        private readonly IExplorerService _explorerRepository;
        private readonly IPublisher _publisher;
        private readonly ICourier _courier;
        private readonly ILogger<SubscribeNewBlocksHandler> _logger;

        public SubscribeNewBlocksHandler(
            IExplorerService explorerRepository, 
            IPublisher publisher, 
            ICourier courier,
            ILogger<SubscribeNewBlocksHandler> logger)
        {
            _explorerRepository = explorerRepository;
            _publisher = publisher;
            _courier = courier;
            _logger = logger;
        }

        public async Task Handle(SubscribeBlockCommand request, CancellationToken cancellationToken)
        {
            await _publisher.Publish(new BlockNotification()
            {
                blockLight = null
            });

            //await _explorerRepository.SubscribeNewBlocksAsync(async (BlockLightDto blockLight) =>
            //{
            //    _publisher.Publish(new BlockNotification()
            //    {
            //        blockLight = blockLight
            //    });
            //}, cancellationToken);


            //_courier.SubscribeWeak<BlockNotification>(HandleBlockAsync);
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
