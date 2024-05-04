using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
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
        protected GlobalFinanceQuery()
        {
            RangeDate = RangeDate.Default;
            Pagination = Pagination.Default;
        }

        public GlobalFinanceQuery(DateTime? from, DateTime? to) : this()
        {
            RangeDate = new RangeDate(from, to);
        }

        public GlobalFinanceQuery(DateTime? from, DateTime? to, int pageSize, int pageNumber) : this(from, to)
        {
            Pagination = new Pagination(pageSize, pageNumber);
        }

        public RangeDate RangeDate { get; set; }
        public Pagination Pagination { get; set; }
    }
}
