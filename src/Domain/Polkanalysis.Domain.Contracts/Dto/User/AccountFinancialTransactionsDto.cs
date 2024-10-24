using Polkanalysis.Domain.Contracts.Dto.Balances;
using Polkanalysis.Domain.Contracts.Dto.Financial;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class AccountFinancialTransactionsDto
    {
        public AccountFinancialTransactionsDto(UserIdentityDto address, DateTime? from, DateTime? to, CurrencyDto totalAmountReceived, CurrencyDto totalAmountSent, PagedResponseDto<TransactionDto> transactions)
        {
            Address = address;
            From = from;
            To = to;
            TotalAmountReceived = totalAmountReceived;
            TotalAmountSent = totalAmountSent;
            Transactions = transactions;
        }

        public UserIdentityDto Address { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public CurrencyDto TotalAmountReceived { get; set; }
        public CurrencyDto TotalAmountSent { get; set; }
        public PagedResponseDto<TransactionDto> Transactions { get; set; }
    }
}
