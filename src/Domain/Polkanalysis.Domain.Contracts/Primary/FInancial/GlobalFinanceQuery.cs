using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.FInancial
{
    public class GlobalFinanceQuery : IRequest<Result<GlobalFinanceDto, ErrorResult>>
    {
        public GlobalFinanceQuery(DateTime? from, DateTime? to)
        {
            From = from;
            To = to;
        }

        public GlobalFinanceQuery(DateTime? from, DateTime? to, int pageSize, int pageNumber) : this(from, to)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int PageSize { get; set; } = Constants.DefaultPageSize;
        public int PageNumber { get; set; } = Constants.DefaultPageNumber;
    }
}
