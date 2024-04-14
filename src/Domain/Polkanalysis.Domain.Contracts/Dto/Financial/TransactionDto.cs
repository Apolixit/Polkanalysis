using Polkanalysis.Domain.Contracts.Dto.Balances;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Financial
{
    public class TransactionDto
    {
        public TransactionDto(uint blockNumber, CurrencyDto amount, string from, string to)
        {
            BlockNumber = blockNumber;
            Amount = amount;
            From = from;
            To = to;
        }

        public uint BlockNumber { get; set; }
        public CurrencyDto Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public TypeTransactionDto GetTypeTransaction(string address)
        {
            if (string.Equals(From, address, StringComparison.OrdinalIgnoreCase))
            {
                return TypeTransactionDto.Send;
            }
            else if (string.Equals(To, address, StringComparison.OrdinalIgnoreCase))
            {
                return TypeTransactionDto.Received;
            }
            
            throw new InvalidOperationException("Invalid transaction");
        }

        public enum TypeTransactionDto
        {
            Received = 0,
            Send = 1,
            Reward = 3,
        }
    }
}
