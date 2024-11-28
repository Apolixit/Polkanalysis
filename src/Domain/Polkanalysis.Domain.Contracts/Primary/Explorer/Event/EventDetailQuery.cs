using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Event
{
    public class EventDetailQuery : IRequest<Result<EventDto, ErrorResult>>, ICached
    {
        public required uint BlockNumber { get; set; }
        public required uint EventIndex { get; set; }

        public int CacheDurationInMinutes => Settings.Constants.Cache.LongCache;
        public string GenerateCacheKey()
            => $"{nameof(EventDetailQuery)}_{BlockNumber}_{EventIndex}";
    }
}
