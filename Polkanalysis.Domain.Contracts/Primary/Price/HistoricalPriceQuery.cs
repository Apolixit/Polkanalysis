using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Price
{
    public class HistoricalPriceQuery : IRequest<Result<HistoricalPriceDto, ErrorResult>>
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
