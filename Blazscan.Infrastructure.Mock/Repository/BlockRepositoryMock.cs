using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Dto.Extrinsic;
using Blazscan.Domain.Contracts.Secondary;

namespace Blazscan.Infrastructure.Mock.Repository
{
    public class ExplorerRepositoryMock : IExplorerRepository
    {
        public Task<BlockDto> GetBlockDetailsAsync(uint blockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockDto> GetBlockDetailsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockDto> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockLightDto> GetBlockLightAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockLightDto> GetBlockLightAsync(uint blockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockLightDto> GetBlockLightAsync(string blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<EventDto> GetEventAsync(uint blockId, uint eventIndex, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<EventDto> GetEventAsync(Hash blockHash, uint eventIndex, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(uint blockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(string blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(ExtrinsicDto extrinsicDto, IEnumerable<Extrinsic> extrinsics, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDto>?> GetEventsLinkedToExtrinsicsAsync(ExtrinsicDto extrinsicDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ExtrinsicDto> GetExtrinsicAsync(uint blockId, uint extrinsicIndex, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ExtrinsicDto> GetExtrinsicAsync(Hash blockHash, uint extrinsicIndex, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(uint blockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(string blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExtrinsicDto>> GetExtrinsicsAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BlockLightDto?> GetLastBlockAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeEventAsync(Action<EventLightDto> eventCallback)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeNewBlocksAsync(Action<BlockLightDto> blockCallback, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
