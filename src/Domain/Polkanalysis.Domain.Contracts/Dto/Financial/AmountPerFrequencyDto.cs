using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Financial
{
    public class AmountPerFrequencyDto<T>
    {
        public AmountPerFrequencyDto(T amount, Frequency frequency)
        {
            Amount = amount;
            Frequency = frequency;
        }

        public T Amount { get; set; }
        public Frequency Frequency { get; set; }
    }

    public enum Frequency
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }
}
