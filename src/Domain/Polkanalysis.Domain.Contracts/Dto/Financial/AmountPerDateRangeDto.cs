using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Financial
{
    public class AmountPerDateRangeDto<T>
    {
        public AmountPerDateRangeDto(T amount, DateTime from, DateTime to)
        {
            Amount = amount;
            From = from;
            To = to;
        }

        public T Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
