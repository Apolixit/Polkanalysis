using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic
{
    public class ExtrinsicDetailQuery : IRequest<Result<ExtrinsicDto, ErrorResult>>, ICached
    {
        public required uint BlockNumber { get; set; }
        public required uint ExtrinsicIndex { get; set; }

        public int CacheDurationInMinutes => Settings.Constants.Cache.LongCache;
        public string GenerateCacheKey()
            => $"{nameof(ExtrinsicDetailQuery)}_{BlockNumber}_{ExtrinsicIndex}";
    }
}
