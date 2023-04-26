﻿using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary
{
    public class EventCommand : IRequest<Result<EventDto, ErrorResult>>
    {
        public required uint BlockNumber { get; set; }
        public required uint EventIndex { get; set; }
    }
}
