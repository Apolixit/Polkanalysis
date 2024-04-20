using Polkanalysis.Domain.Contracts.Dto.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Financial
{
    public class GlobalFinanceDto
    {
        public GlobalFinanceDto(List<TransactionDto> transactions, CurrencyDto volume, List<AmountPerDateRangeDto<double>> volumePerDay, List<AmountPerDateRangeDto<double>> averageTransactionAmountPerDay, DateTime? from, DateTime? to)
        {
            Transactions = transactions;
            Volume = volume;
            VolumePerDay = volumePerDay;
            AverageTransactionAmountPerDay = averageTransactionAmountPerDay;
            From = from;
            To = to;
        }

        public List<TransactionDto> Transactions { get; set; }
        public CurrencyDto Volume { get; set; }
        public List<AmountPerDateRangeDto<double>> VolumePerDay { get; set; }
        public List<AmountPerDateRangeDto<double>> AverageTransactionAmountPerDay { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
